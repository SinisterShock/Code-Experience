## Outside of circle == no \ignore->\ If yes, apply Salzer then Za below /<- ignore/
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
# Adjust for Earth curveature by Power Series equivalent of Bremmer's Formula
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

class PropCalculation:

    def __init__(self):
        self.earthRad = 6370  # earth radius in km
        self.radFactor = 1.333333  # assumed effective radius factor
        self.speed = 299700  # speed of light in air - km/s

        self.effRad = self.radFactor * self.earthRad  # effective earth radius

    def calcprop(self, sigma, freq, epsilon, dist):
        wavelength = self.speed / (1e6 * freq)  # wavelength 1km
        x = 17.97 * sigma / freq
        b1 = math.atan2(epsilon - 1, x)
        b2 = math.atan2(epsilon, x)
        pi = math.pi
        jcon = math.atan2(0, 1)  # new j is a complex number

        P = pi * (dist / wavelength) * math.cos(b2) ** 2 / (x * math.cos(b1))  # numerical distance
        b = 2 * b2 - b1  # phase angle
        K = (wavelength / (2 * pi * self.effRad)) ** (1 / 3) * math.sqrt(x * math.cos(b1)) / math.cos(b2)

        rho = P * (math.cos(b) + jcon * math.sin(b))  # calculate rho
        delta = K * (math.cos(3 * pi / 4 - b / 2)) + jcon * math.sin(3 * pi / 4 - b / 2)  # calculate delta

        rhoNeg = -1 * rho  # makes rho negative for readability
        rhoRoot = math.sqrt(rho)  # square root of rho for readability
        piRhoRoot = math.sqrt(pi * rho)  # square root of pi*rho for readability
        erfcValue = (-1 * jcon * rhoRoot)  # goes inside erfc
        erfc = math.erfc(erfcValue)  # neg tower obj * rhoroot

        zaNorton = 1 + jcon * piRhoRoot * math.exp(rhoNeg) * erfc
        zadjBremmer = zaNorton + (
                    (1 + 2 * rho) * zaNorton - 1 - jcon * piRhoRoot * delta ** 3 / 2 + (rho ** 2 / 2 - 1) *
                    zaNorton + jcon * piRhoRoot * (1 - rho) + 1 - 2 * rho + 5 * rho ** 2 / 6) * delta ** 6

        return zadjBremmer


