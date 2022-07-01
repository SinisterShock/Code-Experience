import math


class Bessel:
    """
    Class for calculating the Bessel function.
    """

    def __init__(self, x):
        """Constructor for the Bessel Function that has the parameter x that is used to initialise
        a variable in the class/object

        Args:
            x(type):  x is a parameter of type float that was used to initialise the variable self.x
        """
        self.x = x
        self.value = None

    def calculatebessel(self):
        """Calculates the value of the Bessel Function
        Updates the value to self.value and also returns the value

        Returns:
            The calculated value of the Bessel Function
        """
        if self.x < 3.0:
            # y is ~1/3 of x
            y = (self.x * 0.33333333)
            # square y
            y = y * y
            # calculate the value temporarily
            self.value = (((((0.00021 * y - 0.0039444) * y + 0.0444479) * y - 0.3163866) * y + 1.2656208) * y -
                          2.2499997) * y + 1.0

        # recalculate y using x
        y = 3.0 / self.x

        # if the value is less than 1000000, use the formula
        if self.x < 1000000:
            # calculate the value of f
            f = (((((0.00014476 * y - 0.00072805) * y + 0.00137237) * y - 0.00009512) * y - 0.00552740) * y -
                 0.00000077) * y + 0.79788456
            # calculate the value of t
            t = (((((0.00552740 * y - 0.00029333) * y - 0.00054125) * y + 0.00262573) * y - 0.00003954) * y -
                 0.04166397) * y - 0.78539816 + self.x

            # calculate the value of the Bessel Function and save it, then return it
            self.value = f * math.cos(t) / math.sqrt(self.x)
            return self.value
        else:
            # set the value of the Bessel Function to 0, then return it
            self.value = 0.0
            return self.value

    def getvalue(self):
        """Gets the value of the Bessel Function

        Returns:
            The calculated value of the Bessel Function
        """
        # if self.value isn't set, calculate it
        if self.value is None:
            self.calculatebessel()
        # return the value
        return self.value
