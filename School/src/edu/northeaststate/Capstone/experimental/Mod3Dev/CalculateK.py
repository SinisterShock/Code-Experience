import math


class CalulateK:

    def __init__(self):
        """
        Constructor for the CalculateK calculation class/object
        """
        self.k = None
        self.klossless = 0.0
        # delta = 0.0
        self.part = 0.0
        self.rms_hem = 0.0
        self.efficiency = 0.0
        self.ploss = 0.0
        self.rloss = 1
        self.towerlist = []
        self.phase = 0
        self.topload = 0
        self.height = 0
        self.topload = 0
        self.ratio = 0
        self.phasefill = 0.1

    def getk(self, power, height, topload, ratio, phase, rms_function, towerlist, rloss):
        """
        getk calculates k and returns it using the given parameters (most of them come from the UI)
        :param power:
        :param height:
        :param topload:
        :param ratio:
        :param phase:
        :param rms_function:
        :param towerlist: - list of towers
        :param rloss:
        :return: calculated value of k
        """
        # LOSSLESS K
        self.rloss = rloss
        c1 = 152.15158 * 1.609344
        part = rms_function
        self.rms_hem = part * part / 2
        for i in range(len(towerlist)):
            # part = rms_theta(el.value[i])
            if phase  == 0:
                self.rms_hem = self.rms_hem + part * part * math.cos(math.pi / 180. * self.phasefill)
            else:
                self.rms_hem = self.rms_hem + part * part * math.cos(math.pi / 180. * phase)

        self.rms_hem = math.sqrt(phase * math.pi / 180 * self.rms_hem)
        self.klossless = c1 * math.sqrt(power) / self.rms_hem

        # LOSSY K
        c2 = 37.256479 * 1.609344
        for j in range(len(towerlist)):
            a = (math.cos(math.pi / 180. * topload) - math.cos(math.pi / 180. * (height + topload)))
            if a == 0:
                a = 0.000001
            self.part = self.klossless * ratio / c2 / a
            if height < 90:
                self.part = self.part * math.sin(math.pi / 180. * (height + topload))

            self.ploss = self.ploss + self.part * self.part

        self.ploss = self.rloss * self.ploss
        self.efficiency = power * 1000. / (power * 1000. + self.ploss)
        self.k = self.klossless * math.sqrt(self.efficiency)
        return self.k

    def getploss(self):
        """
        getploss getter for ploss
        :return: the value of ploss
        """
        return self.ploss

    def getefficiency(self):
        """
        getefficiency getter for efficiency
        :return: the value of efficiency
        """
        return self.efficiency
