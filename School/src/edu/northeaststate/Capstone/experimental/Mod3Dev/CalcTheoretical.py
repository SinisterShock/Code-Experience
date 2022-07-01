import cmath
import math


class CalcTheoretical:  # Theoretical Calculation

    def __init__(self):

        # initialize parameters
        self.theodata = []
        self.theoangle = []
        self.maxdata = 0
        self.vc = []
        self.a1 = 0
        self.pattern = (0, 0)
        self.pat = (0, 0)

    def gettheoreticaldata(self, angle, elevation, k, vert, spacing, ratio, towerlist):
        # if the array isn't empty clear it
        if self.theodata is not None:
            self.theodata.clear()

        # For loop used to set the length of each item in list vc to the length in the tower list
        # for i in range(len(vc)):
        #   vc[i].set_length(num_tower + 1)

        for j in range(len(towerlist)):
            self.pat = (0, 0)

            for i in range(len(towerlist)):
                arg = math.atan2(0, 2 * math.pi * spacing / 360 * math.cos(elevation * math.pi / 180) *
                                 math.cos(math.pi / 180 * (towerlist[j]['orientation'] - towerlist[
                                     i]['orientation'])) + math.pi / 180 * angle)
                self.a1 = vert * ratio
                self.vc[j][i] = cmath.exp(arg) * self.a1
                self.pattern = self.pat + self.vc[j][i]

            self.vc[j][towerlist] = self.pattern
            self.theodata[j] = k * (abs(element) for element in self.pat)

            if len(self.theodata[j]) > self.maxdata:
                self.maxdata = len(self.theoangle[j])

        return self.theodata

    def gettheoreticalangle(self, angle, elevation, vert, spacing, ratio, towerlist):
        # if the array isn't empty clear it
        self.vc = towerlist
        if self.theodata is not None:
            self.theodata.clear()

        # For loop used to set the length of each item in list vc to the length in the tower list
        # for i in range(len(vc)):
        #   vc[i].set_length(num_tower + 1)

        for j in range(len(towerlist)):
            self.pat = (0, 0)

            for i in range(len(towerlist)):
                arg = math.atan2(0, 2 * math.pi * spacing / 360 * math.cos(elevation * math.pi / 180) *
                                 math.cos(math.pi / 180 * (towerlist[j]['orientation'] - towerlist[
                                     i]['orientation'])) + math.pi / 180 * angle)
                self.a1 = vert * ratio
                self.vc[j][i] = cmath.exp(arg) * self.a1
                self.pattern = self.pat + self.vc[j][i]

            self.vc[j][towerlist] = self.pattern
            self.theoangle[j] = (cmath.phase(element) for element in self.pat)

            if len(self.theodata[j]) > self.maxdata:
                self.maxdata = len(self.theoangle[j])

        return self.theoangle

    def gettheoreticalpattern(self, angle, elevation, vert, spacing, ratio, towerlist):
        # if the array isn't empty clear it
        if self.theodata is not None:
            self.theodata.clear()

        # For loop used to set the length of each item in list vc to the length in the tower list
        # for i in range(len(vc)):
        #   vc[i].set_length(num_tower + 1)

        for j in range(len(towerlist)):
            self.pat = (0, 0)

            for i in range(len(towerlist)):
                arg = math.atan2(0, 2 * math.pi * spacing / 360 * math.cos(elevation * math.pi / 180) *
                                 math.cos(math.pi / 180 * (towerlist[j]['orientation'] - towerlist[
                                     i]['orientation'])) + math.pi / 180 * angle)
                self.a1 = vert * ratio
                self.vc[j][i] = cmath.exp(arg) * self.a1
                self.pattern = self.pat + self.vc[j][i]

            self.vc[j][towerlist] = self.pattern

            if len(self.theodata[j]) > self.maxdata:
                self.maxdata = len(self.theoangle[j])

        return self.pattern
