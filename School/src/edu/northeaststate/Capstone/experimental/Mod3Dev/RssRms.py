import math
from Tower import Tower
from CalculateK import CalulateK
from OtherInput import OtherInput
import experimental


class CalculateRssRms:
    def __init__(self, angle, float_el, k, power, ratio):
        """
        Constructor for the RssRms calculation class/object
        :param angle: TODO
        :param float_el: TODO
        :param k: TODO
        :param power: Measured in KW, set through the constants UI fields
        :param ratio: first field in the top creation UI
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
        """
        calcvaluerss gets the rss value based on calculations
        :return: the rss value
        """
        the_rss = 0
        for i in range(0, len(self.towers)):
            the_rss = the_rss + math.pow(self.ratio, 2)

        return self.k*(the_rss**2)

    def calcstddata(self):
        """
        calcstddate gets the std data array that is calculated based on the rss and other values
        :return: an array of numbers representing the std data
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
        """
        calcvaluerms gets the rms value based on theodata
        :return: a float of the rms
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
        """
        calcvaluestd_rms gets the std rms value calculated using the std_data
        :return: a float of the std rms
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
        """
        calcvaluerss - getter for the rss
        :return: the calculated rss
        """
        return self.the_rss

    def calcstddata(self):
        """
        calcstddata - getter for the std data
        :return: the calculated std data
        """
        return self.std_data

    def calcvaluerms(self):
        """
        calcvaluerms - getter for the rms
        :return: the calculated rms data
        """
        return self.the_rms

    def calcvaluestd_rms(self):
        """
        calcvaluestd_rms - getter for the std rms data
        :return: the calculated std rms data
        """
        return self.std_rms
