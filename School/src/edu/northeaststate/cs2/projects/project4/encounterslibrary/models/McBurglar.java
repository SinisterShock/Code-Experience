package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import edu.northeaststate.cs2.projects.project4.util.SimpleDiceRoller;

import java.io.Serializable;

/**
 * Class Name: McBurglar
 * Purpose: An extension of the monster class as a McBurglar
 */
public class McBurglar extends Monster implements Serializable {
    private static int numMcBurglars = 1;
    private static final int McBurglar_MAX_HP = 10000;
    private static final int McBurglar_ATTACK_DAMAGE = 157;
    private static final int McBurglar_ARMOR_CLASS = 34;

    /**
     * Class Name: McBurlgar
     * Purpose: Constructor for the McBurglar Class and sets the super equal to its desired stats
     */
    public McBurglar() {
        super("McBurglar" + numMcBurglars, SimpleDiceRoller.roll(McBurglar_MAX_HP), McBurglar_ATTACK_DAMAGE, McBurglar_ARMOR_CLASS);
        numMcBurglars += 1;
    }

    /**
     * Class Name: toString
     * Purpose: returns the string for a McBurglar
     */
    @Override
    public String toString() {
        return "McBurglar{} " + super.toString();
    }
}
