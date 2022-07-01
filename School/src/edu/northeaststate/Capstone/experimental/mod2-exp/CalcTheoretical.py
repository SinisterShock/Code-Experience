import cmath
import math
from CalculateK import CalculateK


class CalcTheoretical:  # Theoretical Calculation
    """
    Theoretical Calculation
    """
    def __init__(self):
        """Constructor for the CalcTheoretical class with the only parameter being self. All variables initialised in the
        constructor are empty arrays or of value 0
        """

        # initialize parameters
        self.theodata = []
        self.theoangle = []
        self.maxdata = 0
        self.vc = []
        self.a1 = 0
        self.pattern = (0, 0)
        self.pat = (0, 0)

    def calculate_theo(self, k, towerlist):
        """calculate_theo method uses the parameters k and towerlist to provide values that are parsed through with a for
       loop that used in calculating the self.theodata and then returned.

       Args:
         k(float): k is a float that is used to perform a calculation that result in the value of self.theodata
         towerlist(list): towerList is a list used to hold values that are created by the calculations in the calculate_theo method

        Returns:
             self.theodata
        """
        # Clear if the array isn't empty
        if self.theodata is not None:
            self.theodata.clear()

        # Define variables
        self.theodata = []
        self.theoangle = []
        maxdata = 0

        # this might be el
        num_el = 18  # 0,5,...,85 is 18
        delta = 90 / num_el
        #el = (num_el, delta, 0)
        el = 18

        vc = []
        for i in range(360):
            vc.append([])
            self.theodata.append(0)
            self.theoangle.append(0)
            for j in range(len(towerlist)):
                vc[i].append(j)


        vert = .0
        a1 = complex(0, 0)  # vertical elevation pattern el measured 9 at horizon

        for j in range(360):
            pat = 0
            for k in range(len(towerlist)):
                # vertical factor not calculated since it is 2d only
                vert = 1
                # this is a complex number
                argu = math.atan2(0, 2. * math.pi * towerlist[k]['spacing'] / 360. * math.cos(towerlist[k]['height'] * math.pi / 180.) * math.cos(math.pi / 180. * (j - towerlist[k]['orientation'])) + math.pi / 180. * towerlist[k]['phase'])
                #argu = complex(0, 2. * math.pi * towerlist[k]['spacing'] / 360. * math.cos(el * math.pi / 180.) * math.cos(math.pi / 180. * (j - towerlist[k]['orientation'])) + math.pi / 180. * towerlist[k]['phase'])
                a1 = vert * towerlist[k]['ratio']
                vc[j][k] = cmath.exp(argu.real) * a1
                pat = pat + vc[j][k]

            self.theodata[j] = k * pat.real / 100
            self.theoangle[j] = pat

            if self.theodata[j] > maxdata:
                maxdata = self.theodata[j]

        return self.theodata


    def gettheoreticaldata(self, angle, elevation, k, vert, spacing, ratio, towerlist):
        """gettheoreticaldata has the parameters angle, elevation, k, vert, spacing, ratio, and towerlist that are used
           within this method to perform calculations that result in the value of self.theodata which is returned.

           Args:
             angle(float): The angle parameter is of type float and is used in the calculation that returns the value of self.theodata
             elevation(float): The elevation parameter is of type float and is used in the calculation that returns the value of self.theodata
             k(float): The k parameter is of type float and is used in the calculation that returns the value of self.theodata
             vert(float): The vertical parameter is of type float and is used in the calculation that returns the value of self.theodata
             spacing(float): The spacing parameter is of type float and is used in the calculation that returns the value of self.theodata
             ratio(float): The ratio parameter is of type float and is used in the calculation that returns the value of self.theodata
             towerlist(list): The towerlist parameter is of type list and it stores values that are the result of calculations

           Returns:
                self.theodata The theoretical data that is calculated from the parameters that are passed to this method
        """
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
        """gettheoreticalangle assigns the parameters angle, elevation, vert, spacing, ratio, and towerlist
        into different locations in the method to calculate the value of self.theoangle which is returned.

           Args:
             angle(float): The angle parameter is of type float and is used in the calculation
             that returns the value of self.theodata
             elevation(float): The elevation parameter is of type float and is used in the
             calculation that returns the value of self.theodata
             vert(float): The vertical parameter is of type float and is used in the calculation
             that returns the value of self.theodata
             spacing(float): The spacing parameter is of type float and is used in the calculation
             that returns the value of self.theodata
             ratio(float): The ratio parameter is of type float and is used in the calculation
             that returns the value of self.theodata
             towerlist(list): The towerlist parameter is of type list and it stores values that
             are the result of calculations

           Returns:
                self.theoangle The theoretical angle that is calculated
        """
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
        """gettheoreticalpattern assigns the parameters angle, elevation, vert, spacing, ratio, and towerlist
        into different locations in the method to calculate the value of self.pattern which is returned.

           Args:
             angle(float): The angle parameter is of type float and is used in the calculation
             that returns the value of self.theodata
             elevation(float): The elevation parameter is of type float and is used in the
             calculation that returns the value of self.theodata
             vert(float): The vertical parameter is of type float and is used in the calculation
             that returns the value of self.theodata
             spacing(float): The spacing parameter is of type float and is used in the
             calculation that returns the value of self.theodata
             ratio(float): The ratio parameter is of type float and is used in the calculation
             that returns the value of self.theodata
             towerlist(list): The towerlist parameter is of type list and it stores values
             that are the result of calculations

           Returns:
                self.pattern The theoretical pattern that is calculated
        """
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
