class OtherInput:
    def __init__(self, distance, r_loss, frequency, power, physical_length):
        self.distance = distance
        self.r_loss = r_loss
        self.frequency = frequency
        self.power = power
        self.physical_length = physical_length

    def getdistance(self):
        return self.distance

    def getr_loss(self):
        return self.r_loss

    def getfrequency(self):
        return self.frequency

    def getpower(self):
        return self.power

    def getphysical_length(self):
        return self.physical_length
