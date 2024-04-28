#!/bin/bash
# The above line is called a shebang. It tells the command interpreter
# to use bash.

# $filename is the output file
filename="memorylog.txt"
# Note: in the above line, there can be NO spaces on either side
# of the '='

# since we're appending to the file, let's delete any old files that
# are from the previous runs
rm $filename >/dev/null 2>&1
# '/dev/null/ 2>&1' dumps error output that would be
# displayed if there wasn't a 'memorylog.txt' file
# to delete

# infinite loop
while true
do
     # Formatting the output file
     echo "**************************" >> $filename
     # get the dat/timestamp
     date >> $filename
     echo "*************************" >> $filename
     # get the info and append it to the output file
     cat /proc/meminfo | grep -E Active:\|Inactive:  >> $filename
     echo "" >> $filename

     # wait 5 seconds
     sleep 5s
done

exit 0
