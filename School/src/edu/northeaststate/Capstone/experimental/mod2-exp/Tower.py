class Tower:
    """
        Tower class used to represent a single tower.
    """

    def __init__(self, tower_num, ratio, phase, spacing_deg, orient_deg, reference_tower, height_deg, top_load_deg):
        """Initialize a tower object using the parameters tower_num, ratio, phase, spacing_deg, reference_tower, height_deg
           and top_load_deg that is the user's input and the parameters are used to initialize variables int the
           class.

           Args:
             tower_num(float): tower_num is a parameter of type float that was used to initialize the variable
                self.tower_num The tower number used to identify the tower in the model.
             ratio(float): ratio is a parameter of type float that was used to initialize the variable self.ratio
             phase(float): phase is a parameter of type float that was used to initialize the variable self.phase
             spacing_deg(float): spacing_deg is a parameter of type float that was used to initialize the variable self.spacing_deg
             orient_deg(float): orient_deg is a parameter of type float that was used to initialize the variable self.orient_deg
             reference_tower(float): reference_tower is a parameter of type float that was used to initialize the variable self.reference_tower
                (Used if the tower's orientation is relative to another tower other than the first.)
             height_deg(float): height_deg is a parameter of type float that was used to initialize the variable self.height_deg
             top_load_deg(float): top_load_deg is a parameter of type float that was used to initialize the variable self.top_load_deg
                (Used if toploaded)
        """
        self.tower_num = tower_num
        self.ratio = ratio
        self.phase = phase
        self.spacing_deg = spacing_deg
        self.orient_deg = orient_deg
        self.reference_tower = reference_tower
        self.height_deg = height_deg
        self.top_load_deg = top_load_deg

    def gettower_num(self):
        """gettower_num returns the value of self.tower_num.

           Args:
             self

           Returns:
               self.tower_num
        """
        return self.tower_num

    def getratio(self):
        """getratio returns the value of self.ratio.

           Args:
             self

           Returns:
               self.ratio
        """
        return self.ratio

    def getphase(self):
        """getphase returns the value of self.getphase.

           Args:
             self

           Returns:
               self.getphase
        """
        return self.phase

    def getspacing(self):
        """getspacing returns the value of self.spacing_deg.

           Args:
             self

           Returns:
               self.spacing_deg
        """
        return self.spacing_deg

    def getorientation(self):
        """getorientation returns the value of self.orient_deg.

           Args:
             self

           Returns:
               self.orient_deg
        """
        return self.orient_deg

    def getheight(self):
        """getheight returns the value of self.height_deg.

           Args:
             self

           Returns:
               self.height_deg
        """
        return self.height_deg

    def gettop_load_deg(self):
        """gettop_load_deg returns the value of self.top_load_deg.

           Args:
             self

           Returns:
               self.top_load_deg
        """
        return self.top_load_deg
