#!/bin/bash
#################################################################
#	Jack Ramsey
#	12/16/2014
#
#	Purpose: This script will delete a set of users from the
#		system. The user set is defined in a text file.
#		For compatability with the museradd script,
#		the text file is a space-delimited list with
#		three fields per line: username firstname lastname.
#		Note that it would be sufficient to simply use
#		a list of the ids to be deleted, but this way,
#		the admin can maintain lists of added users over
#		time and submit a modified list for deleting 
#		users with little need for revision.
#################################################################

# check parameters. if only one, an error message is generated
# and execution terminates. Note that this script does not attempt
# to determine that the content of the text file, if provided, is 
# of the correct format. You the user will need to make sure to 
# designate the correct file.
if [ '$#' = 1 ]; then
	echo "Usage: dusers filename"
	echo "You need to specify a valid filename!"
	exit 1
fi

# check to ensure that the user executing this script has root
if [ $(id -u) -eq 0 ]; then     # if so:
while read f1 f2 f3 		# read in a record
do

        echo "Deleting account $f1 ($f2 $f3)"

	egrep "^$f1" /etc/passwd >/dev/null 	# check to see if the account exists
	if [ $? -ne 0 ]; then			# if not:
		echo "User $f1 not found! Can't delete"
	else					# if so
		rm -r /var/mail/"$f1"
		rm -r /home/"$f1"
		userdel "$f1"		# delete the user. -r forces deletion of home
						# directory files and folders
		[ $? -eq 0 ] && echo "User $f1 deleted"
	fi

done < $1  	# end of loop

# if the invoking user isn't root
else
	echo "Only root can delete a user from the system"
	exit 2
fi
################# End ##################
