import math


class Bessel:
    """Class for Bessel Function"""
    value = 0.0

    def __init__(self, x):
        if x < 3.0:
            y = (x * 0.33333333)
            y = y * y
            self.value = (((((
                                     0.00021 * y - 0.0039444) * y + 0.0444479) * y - 0.3163866) * y + 1.2656208) * y - 2.2499997) * y + 1.0

        y = 3.0 / x

        if x < 1000000:
            f = (((((
                            0.00014476 * y - 0.00072805) * y + 0.00137237) * y - 0.00009512) * y - 0.00552740) * y - 0.00000077) * y + 0.79788456
            t = (((((
                            0.00552740 * y - 0.00029333) * y - 0.00054125) * y + 0.00262573) * y - 0.00003954) * y - 0.04166397) * y - 0.78539816 + x
            self.value = f * math.cos(t) / math.sqrt(x)
        else:
            self.value = 0.0

    def getvalue(self):
        return self.value
