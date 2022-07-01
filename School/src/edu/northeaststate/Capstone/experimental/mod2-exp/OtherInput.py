class OtherInput:
    """Class OtherInput contains a constructor for miscellaneous values that are use in the application"""
    def __init__(self, distance, r_loss, frequency, power, physical_length):
        """Constructor takes the parameters distance, r_loss, frequency, power, and physical_length and
           uses their values to initialize the current objects values of the same name then defines a getter
           method for each variable.

           Args:
               distance(float): distance is a parameter of type float that was used to initialize the variable self.distance
               r_loss(float): r_loss is a parameter of type float that was used to initialize the variable self.r_loss
               frequency(float): frequency is a parameter of type float that was used to initialize the variable self.frequency
               power(float): power is a parameter of type float that was used to initialize the variable self.power
               physical_length(float): physical_length is a parameter of type float that was used to initialize the variable self.physical_length
        """
        self.distance = distance
        self.r_loss = r_loss
        self.frequency = frequency
        self.power = power
        self.physical_length = physical_length

    def getdistance(self):
        """Defines a method named getdistance that returns the value of distance for the object

           Args:
               self

           Returns:
               self.distance
        """
        return self.distance

    def getr_loss(self):
        """Defines a method named getr_loss that returns the value of r_loss for the object

           Args:
               self

           Returns:
               self.r_loss
        """
        return self.r_loss

    def getfrequency(self):
        """Defines a method named getfrequency that returns the value of frequency for the object

           Args:
               self

           Returns:
               self.frequency
        """
        return self.frequency

    def getpower(self):
        """Defines a method named getpower that returns the value of power for the object

           Args:
               self

           Returns:
               self.power
        """
        return self.power

    def getphysical_length(self):
        """Defines a method named getphysical_length that returns the value of physical_length for the object

           Args:
               self

           Returns:
               self.physical_length
        """
        return self.physical_length
