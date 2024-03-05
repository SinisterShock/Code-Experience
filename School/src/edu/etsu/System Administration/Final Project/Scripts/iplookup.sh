#!/bin/bash
############################################################################
#	iplookup.sh
#	  Author:	    Tyler Burleson
#	  Date:		    4/22/2024
# 	  Last revised:	2/28/2024
#	  Description:	Identifies attempted logins on the server
#			- Checks an input file for IP addresses
#			- Counts the number of attempts for each
#			- Discards IP addresses with <100 attempts
#			- Menu driven
#			  - 1. Displays IP addresses
#			  - 2. Displays detailed IP information
#			  - 3. Adds IP addresses to UFW
#			       - Makes sure IP isn't already in UFW
#                  - If it is, skip it
#                  - If it isn't, add it
#			  - 4. Displays firewall rules
#			  - 5. Exits script
#
############################################################################

############### ERROR CHECKING ######################
# have to sudo to access log files
# CODE GOES HERE
if [ "$(id -u)" -ne 0 ]; then
  echo "Please use the sudo user to continue."
  exit 1
fi



# check for proper usage (correct # of arguments - 0)
# CODE GOES HERE
if [ "$#" -ne 1 ]; then
    echo "Please attach a file to run to get the IP addresses"
    exit 1
fi
############# DONE ERROR CHECKING ##################

#variables
fileToUse="$1"
userInput="0"
functionCounter="0"
attempsMade="0"
ifIPIsFound="false"


#color variables
NOCOLOR='\033[0m'
RED='\033[0;31m'
GREEN='\033[0;32m'
CYAN='\033[0;36m'
YELLOW='\033[0;33m' 
PURPLE='\033[0;35m' 

#REGEX VAR(S) HERE
QUAD="(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])"
IP="\b$QUAD\.$QUAD\.$QUAD\.$QUAD\b"

regs="$(cut -d' ' -f7-20 $fileToUse | grep -Eo $IP | sort -g | uniq -c )"
ufwRules="$(sudo ufw status | grep -Eo $IP)"



printf "Working... "
uniqueIPsCount="0" #sets the unique ip address to 0 
printf "${GREEN}DONE! "


#get all offenders (100+) from input file. In the input file, the IP address
#is recorded three times for each offense.
#filtering on "rhost=$IP" trims off the other two entries
function get_offenders {
    printf "${YELLOW}"
    grep -E -o "rhost=$IP" "$fileToUse" | awk -F= '{print $NF}' | sort | uniq -c | awk '{if ($1 >= 100) print $0}'

    printf "${NOCOLOR}"
}

#display the unique IP addresses on demand
function display_unique_ips {
    printf "${YELLOW}"
    grep -E -o "rhost=$IP" "$fileToUse" | awk -F= '{print $NF}' | sort | uniq -c | awk '{printf "IP: %s \t\tAttempts: %s\n", $2, $1}'
    printf "${NOCOLOR}"
}

#print detailed info on the offenders
function print_info {
    uniqueIPs=$(display_unique_ips) # sets the previous function to var uniqueIPs
    functionCounter=0 #sets counter to 0

    echo "$uniqueIPs" | awk '{print $2}' | while read -r val; do
    echo -e "IP Information:"
    curl -s "ipinfo.io/${val}?token=906150f9a1fb5d" | less -F
    echo 
    echo -e "Attempted Connections: $(grep -E -c "rhost=$val" "$fileToUse")"
    echo
done | less -F  
}

#add the IPs to the firewall. if 'y', have to check
#and make sure that the IP isn't already in the firewall
function add_ips_to_ufw {
    offenderIPs=$(get_offenders)
    for val in $offenderIPs; do
        if [[ $val =~ ^$IP$ ]]; then
            if [ "$(sudo ufw status | grep -c "deny from $val")" -eq 0 ]; then
                printf "${PURPLE}Adding $val... "
                sudo ufw deny from $val
                printf "${NOCOLOR}\n"
            else
                echo "IP already in UFW: $val"
            fi

        fi
    done
}

function show_firewall {
    sudo ufw status numbered | less
}

#count both total attempts and unique IP addresses
#code goes here
uniqueIPsCount="$(cut -d' ' -f7-20 $fileToUse | grep -Eo $IP | sort -g | uniq | wc -l)"
totalIPsCount="$(cut -d' ' -f7-20 $fileToUse | grep -Eo $IP | sort -g  | wc -l)"

#menu goes here (infinite loop)
printf "\n${RED} There were $totalIPsCount total attempts from $uniqueIPsCount unique IP addresses "
echo 

function switchStatement {
    case $userInput in
        1)
            display_unique_ips
            userInput="0"
            functionCounter="0"
            ;;
        2)
            print_info 
            userInput="0"
            functionCounter="0"
            ;;
        3)
            add_ips_to_ufw
            userInput="0"
            functionCounter="0"
            ;;
        4)
            show_firewall
            userInput="0"
            ;;
        5)
            userInput="5"
            ;;
        *)
            echo -e "${RED}ENTER 1-5"
            userInput="0"
            ;;
    esac
}

while [ $userInput -ne 1 ] && [ $userInput -ne 2 ] && [ $userInput -ne 3 ] && [ $userInput -ne 4 ] && [ $userInput -ne 5 ];
do 
    echo ""
    echo -e "${GREEN} 1. Get unique IP addresses "
    echo -e "${GREEN} 2. Show detailed information ('q' to quit) "
    echo -e "${GREEN} 3. Add new offenders to UFW "
    echo -e "${GREEN} 4. Show firewall rules ('q' to quit) "
    echo -e "${GREEN} 5. Quit "
    printf "${GREEN} Choose an option: ${NOCOLOR} "
    read userInput

    switchStatement
done

###################################################################
echo
printf "${GREEN}Done! ${CYAN}GOODBYE!${NOCOLOR}"
echo 