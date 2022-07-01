# Experimental implementation of propagation calculator
# Author: Module 2 via Tyler
# Date 3/18/22

import math
import sys


def propogationcalculator(ratio, zenith, spacing, orientation, height):
    # This system is NOT top loaded:
    fcc_fitheta = (math.cos(height * math.sin(zenith)) - math.cos(height))/((1-math.cos(height)) * math.cos(zenith))
    theta = zenith
    fcc_fi = ratio
    fcc_si = spacing
    fcc_phi = orientation
    phi = 0
    # TODO- Change this to the greek letter
    fcc_electricalheight = height

    # return the result of the calculations
    return float(((fcc_fi*fcc_fitheta) / fcc_si) * math.cos(theta) * math.cos(fcc_phi - phi) + fcc_electricalheight)


def main():
    if input("Is the system top loaded? (y/n) ") == "y":
        # This system IS top loaded:
        # TODO - Add top loaded functionality

        print("Sorry, we don't do that yet.")
        sys.exit()
    else:
        # create a list to hold the points
        pointlist = []

        if input("Auto input? (y/n): ") == "n":
            # TODO: In the future it won't ask for inputs, but instead take them from the controller nor will it need to use a loop to accept multiple inputs
            while True:
                # ask for inputs from the user
                ratio = float(input("Enter the ratio: "))
                zenith = float(input("Enter the Zenith: "))
                spacing = float(input("Enter the spacing from the origin tower: "))
                orientation = float(input("Enter the orientation: "))
                height = float(input("Enter the height: "))

                # create tuple called point to hold the calculated data results
                point = orientation, propogationcalculator(ratio, zenith, spacing, orientation, height)

                # add the point to the list
                pointlist.append(point)

                if input("Add another? (y/n) ") == "n":
                    break
        else:
            for i in range(360):
                # create tuple called point to hold the calculated data results
                point = i, propogationcalculator(1.4, 242, 150, i, 70.8)

                # add the point to the list
                pointlist.append(point)

    # print the list
    for i in pointlist:
        print(i)


main()