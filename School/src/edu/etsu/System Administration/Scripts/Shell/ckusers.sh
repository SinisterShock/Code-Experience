#!/bin/bash
cat /etc/passwd | egrep "1[0-9]{3}" /etc/passwd | egrep -o "^[a-z]+" | sort
