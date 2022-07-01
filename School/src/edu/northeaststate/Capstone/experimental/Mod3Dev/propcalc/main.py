## Outside of circle == no \ignore->\ If yes, apply Sailzer then Za below /<-ignore/
# Flat-Earth attenuation by Power Series if above == no
# NORTON'S FORMULA 1st equation in Flow-Chart
# Za = 1 + j√(πρ)e^-ρ erfc(-j√(ρ))
# j = Tower_Object or Value where placed on theo calc angel
# π = pi == math.pi
# ρ = rho // P = Magnitude // b = phase angle // ρ = P * math.exp(jb)
# -ρ = negative rho or negRho
# √(ρ) // Magnitude = √(P) // phase = b/2 // √(ρ) = √(P) * math.exp(jb /2)
# While ρ is under √ use the above formula to find square root of ρ first.
# e^-ρ = math.e to the -ρ power (math.exp(-ρ))
# ^ = exponent of previous number
# erfc = complementary error function == math.erfc
# erfc can only take one value
# so erfcValue == (-j√(ρ))
#
## On yes condition after Norton's \ignore->\ No condition is Bremmer equation 24 /<-ignore/
# Adjust for Earth curvature by Power Series equivalent of Bremmer's Formula
# BREMMERS FOMULA Used 2nd in Flow-Chart
# Zadj = Za + [(1 + 2ρ)Za - 1 – j√(πρ)]δ^3 / 2 + [(ρ^2 / 2 - 1)Za + j√(πρ)(1 – ρ) + 1 - 2ρ + 5ρ^2 / 6]δ^6
# Za = Norton's formula above
# j = tower_object
# ρ = rho // P = Magnitude // b = phase angle // ρ = P * math.exp(jb)
# j√(πρ) = j * √ (pi * (P * math.exp(jb)))
# π = pi
# πρ = pi * rho
# δ = delta // Magnitude = K // Phase angle = 135 degrees minus b / 2 // δ = K * exp(j(3π / 4 - b / 2))
# ^ = exponent of previous number

## Flow chart states that we should have the amplitude of Complex Attenuation after these 2 equations

import math
# mod2 practice equation
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


# Mod3 equations
def PropCalc(tower_obj):  ## take in J value which is expected to be tower_object
    rho = 5 # ρ = P * math.exp(jb)
    delta = 5 # δ = K * exp(j(3π / 4 - b / 2))
    pi = math.pi
    rhoNeg = -1 * rho  # makes rho neg for easier read of equation
    rhoRoot = math.sqrt(rho)  # √(ρ) = √(P) * math.exp(jb /2)
    piRhoRoot = math.sqrt(pi * rho) # get √ of rho from above first then times by pi, then do square root
    erfcValue = (-1 * int(tower_obj) * rhoRoot)  # goes inside erfc
    erfc = math.erfc(erfcValue)  # neg tower obj * rhoroot

    # Nortons Equation first
    zaNorton = 1 + int(tower_obj) * piRhoRoot * math.exp(rhoNeg) * erfc

    # Bremmer Equation Next and return
    ZadjBremmer = zaNorton + ((1 + 2 * rho) * zaNorton - 1 - tower_obj * piRhoRoot * delta ** 3 / 2 + (rho ** 2 / 2 - 1) *
                 zaNorton + tower_obj * piRhoRoot * (1 - rho) + 1 - 2 * rho + 5 * rho ** 2 / 6) * delta ** 6
    return ZadjBremmer


def main():

    pointlist = []

    if input("Auto input? (y/n): ") == "n":

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
        # take tuple point i at the 1st index.
        # Returns number that would be plotted on theo graph?
        mod2 = i[1]
        print("Mod2Calc = " + str(mod2))
        print("Mod3Calc = " + str(PropCalc(mod2)))


main()

