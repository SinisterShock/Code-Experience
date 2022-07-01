import math
import scipy.special
import cmath


class CalculateK:
    """
    Class that calculates the K value with the given data
    """

    def __init__(self):
        """Constructor for the CalculateK classes only parameter is self. All variables are initialised
           with 0/0.0 except self.k = None, self.rloss = 1, and phasefill = 0.1
        """
        self.k = None
        self.klossless = 0.0
        self.part = 0.0
        self.rms_hem = 0.0
        self.rmstheta = 0.0
        self.efficiency = 0.0
        self.ploss = 0.0
        self.rloss = 1
        phase = 0
        height = 0
        ratio = 0
        phasefill = 0.1

    def getk(self, power, towerlist):
        """getk calculates k then returns the value using the given parameters power, and towerlist

           Args:
             power(float): power is a parameter of type float used in a calculation to find the value of self.k
             towerlist(list): towerlist is a parameter of value list that contains values one being height that is used
             in the calculation to get the value for self.k

           Returns:
                self.k the calculated value of k
        """
        # Define the variables
        self.rloss = 1  # set 1 ohm
        self.ploss = 0
        topload = 0
        num_el = 18  # 0,5,...,85 is 18
        delta = 90 / num_el
        el = (num_el, delta, 0)

        # LOSSLESS K
        c1 = 152.15158 * 1.609344  # FCC Constant converted from mV/m @ mile to @ km
        part = self.rms_theta(towerlist, el[0])
        self.rms_hem = part * part / 2
        for i in range(len(el)):
            self.part = self.rms_theta(towerlist, el[i])
            self.rms_hem = self.rms_hem + part * part * math.cos(math.pi / 180. * el[i])

        self.rms_hem = math.sqrt(delta * math.pi / 180 * self.rms_hem)
        self.klossless = c1 * math.sqrt(power) / self.rms_hem

        # LOSSY K                  # topload and sin from RON
        c2 = 37.256479 * 1.609344  # FCC Constant converted from mile to km
        for j in range(len(towerlist)):
            a = (math.cos(math.pi / 180. * topload) - math.cos(math.pi / 180. * (towerlist[j]['height'] + topload)))
            if a == 0:
                a = 0.000001
            self.part = self.klossless * towerlist[j]['ratio'] / c2 / a
            if towerlist[j]['height'] < 90:
                self.part = self.part * math.sin(math.pi / 180. * (towerlist[j]['height'] + topload))

            self.ploss = self.ploss + self.part * self.part

        self.ploss = self.rloss * self.ploss
        self.efficiency = power * 1000. / (power * 1000. + self.ploss)
        self.k = self.klossless * math.sqrt(self.efficiency)
        return self.k

    def getploss(self):
        """getploss getter for ploss

        Returns:
            the value of ploss
        """
        return self.ploss

    def getefficiency(self):
        """getefficiency getter for efficiency

        Returns:
            The value of efficiency
        """
        return self.efficiency

    def rms_theta(self, towerlist, arg):
        """rms_theta calculates the rms of theta

        Returns:
            The rms of theta
        """

        rms = 0.0

        # Loop through each tower, in that loop run another loop for each tower again to compare each tower to the top tower
        # [first loop(tower1 compared against 1,2,3 and 4), second loop(tower2 compared against 1,2,3 and 4)...]
        for i in range(len(towerlist)):
            for j in range(len(towerlist)):
                """ Below vert factor"""
                gi = towerlist[i]['height'] * math.pi / 180
                gj = towerlist[j]['height'] * math.pi / 180
                if arg == 90 or gi == 0:
                    factori = 0
                else:
                    factori = (math.cos(gi * math.sin(arg * math.pi / 180)) - math.cos(gi))/(1-math.cos(gi))/math.cos(arg*math.pi/180)
                if arg == 90 or gj == 0:
                    factorj = 0
                else:
                    factorj = (math.cos(gj * math.sin(arg * math.pi / 180)) - math.cos(gj))/(1-math.cos(gj))/math.cos(arg*math.pi/180)

                """ Above vert factor"""
                value = towerlist[i]['ratio'] * towerlist[j]['ratio'] * factori * factorj
                psi = towerlist[i]['phase'] - towerlist[j]['phase']

                loci = complex(towerlist[i]['spacing'], 0) * complex(math.cos(math.pi / 180 * towerlist[i]['orientation']), math.sin(math.pi / 180 * towerlist[i]['orientation']))
                locj = complex(towerlist[j]['spacing'], 0) * complex(math.cos(math.pi / 180 * towerlist[j]['orientation']), math.sin(math.pi / 180 * towerlist[j]['orientation']))

                s = abs(loci - locj)

                value = value * math.cos(math.pi / 180 * psi) * scipy.special.j0(math.pi / 180 * s * math.cos(math.pi / 180 * arg))
                rms = rms + value
                self.rmstheta = rms
        return self.rmstheta
