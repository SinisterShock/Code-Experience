import math
from Tower import Tower
from CalculateK import CalculateK
from OtherInput import OtherInput


class CalculateRssRms:
    def __init__(self, angle, float_el, k, power, ratio):
        """Constructor for the RssRms calculation class/object that has the self, angle, float_el, k, power, and ratio
           as parameters that are used to initialize the objects variables.

           Args:
              angle(float): angle is a parameter of type float that was used to initialize the variable self.a
              float_el(float): float_el is a parameter of type float that was used to initialize the variable self.el
              k(float): k is a parameter of type float that was used to initialize the variable self.k
              power(float): power is a parameter of type float that was used to initialize the variable self.power
              ratio(float): ratio is a parameter of type float that was used to initialize the variable self.ratio
        """
        # Define variables to be used across the object
        self.a = angle
        self.el = float_el
        self.k = k
        self.power = power
        self.ratio = ratio

        # TODO - this probably needs to be pulled in from somewhere else
        self.towers = []
        # TODO - figure out what this does and needs to be, does it need to be blank?
        self.theodata = []  # placeholder theodata list declaration

        # Calculate and set the rss
        self.the_rss = self.calcvaluerss()

        # Calculate and set std data
        self.std_data = self.calcstddata()

        # CALCULATE RMS (ROOT MEAN SQUARE) VALUES
        self.the_rms = self.calcvaluerms()
        self.std_rms = self.calcvaluestd_rms()

    def calcvaluerss(self):
        """calcvaluerss gets the rss value based on calculations

           Args:
              self

           Returns:
               the rss value
        """
        the_rss = 0
        for i in range(0, len(self.towers)):
            the_rss = the_rss + math.pow(self.ratio, 2)

        return self.k*(the_rss**2)

    def calcstddata(self):
        """calcstddate returns the std_data array that contains the results of calculations performed in the method

           Args:
              self

           Returns:
                std_data
        """
        std_data = []
        q = 0  # std_vert_factor(shortest_height_index, el) needs access the std_vert_factor() function
        q1 = .025 * self.the_rss * q
        q2 = 10. * q * (self.power ** 2)

        if q1 > q2:
            q = q1
        else:
            q = q2

        # For loop that uses the value of n that is an attribute of the angle object to iterate through the theodata[]
        # list to use values to perform an equation with result values then being added to std_data list
        for i in range(0, self.a):
            std_data[i] = 1.05 * ((self.theodata[i] * self.theodata[i] + q * q) ** 2)

        return std_data

    def calcvaluerms(self):
        """calcvaluerms returns the the_rms value by performing a calculation using the std_data then performing division
           on the_rms

           Args:
              self

           Returns:
               value of type float
        """
        # CALCULATE RMS (ROOT MEAN SQUARE) VALUES
        the_rms = 0

        # For loop that uses the value of n that is an attribute of the angle object to iterate through the theodata[]
        # list
        # to use values perform an equation with their values and assign the value to the_rms and std_rms
        for i in range(0, self.a - 1):
            the_rms = the_rms + self.theodata[i] * self.theodata[i]

        return the_rms / float(self.a - 1)

    def calcvaluestd_rms(self):
        """calcvaluestd_rms returns the std_rms value by performing a calculation using the std_data then performing division
           on std_rms

           Args:
              self

           Returns:
               value of type float
        """
        # CALCULATE RMS (ROOT MEAN SQUARE) VALUES
        std_rms = 0

        # For loop that uses the value of n that is an attribute of the angle object to iterate through the theodata[]
        # list
        # to use values perform an equation with their values and assign the value to the_rms and std_rms
        for i in range(0, self.a - 1):
            std_rms = std_rms + self.std_data[i] * self.std_data[i]

        return std_rms / float(self.a - 1)

    def calcvaluerss(self):
        """ calcvaluerss returns the value for the self.the_rss variable

            Args:
               self

            Returns:
                self.the_rss
        """
        return self.the_rss

    def calcstddata(self):
        """calcstddata  returns the value for the self.std_data variable

            Args:
               self

            Returns:
                self.std_data
        """
        return self.std_data

    def calcvaluerms(self):
        """calcvaluerms returns the value for the self.the_rms variable

            Args:
               self

            Returns:
                self.the_rms
        """
        return self.the_rms

    def calcvaluestd_rms(self):
        """calcvaluestd_rms returns the value for the self.std_rms variable

            Args:
               self

            Returns:
                self.std_rms
        """
        return self.std_rms
