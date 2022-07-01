class Tower:
    def __init__(self, tower_num, ratio, phase, spacing_deg, orient_deg, reference_tower, height_deg, top_load_deg):
        self.tower_num = tower_num
        self.ratio = ratio
        self.phase = phase
        self.spacing_deg = spacing_deg
        self.orient_deg = orient_deg
        self.reference_tower = reference_tower
        self.height_deg = height_deg
        self.top_load_deg = top_load_deg

    def gettower_num(self):
        return self.tower_num

    def getratio(self):
        return self.ratio

    def getphase(self):
        return self.phase

    def getspacing(self):
        return self.spacing_deg

    def getorientation(self):
        return self.orient_deg

    def getheight(self):
        return self.height_deg

    def gettop_load_deg(self):
        return self.top_load_deg