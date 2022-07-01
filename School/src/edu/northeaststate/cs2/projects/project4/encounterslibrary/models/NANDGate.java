package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import edu.northeaststate.cs2.projects.project4.util.SimpleDiceRoller;

import java.io.Serializable;


/**
 * Class Name: NANDGate
 * Purpose: An extension of the monster class as a NAND Gate
 */
public class NANDGate  extends Monster implements Serializable {
    private static int numGATES = 1;
    private static final int NANDGATES_MAX_HP = 800;
    private static final int NANDGATES_ATTACK_DAMAGE = 43;
    private static final int NANDGATES_ARMOR_CLASS = 23;

    /**
     * Class Name: NANDGate
     * Purpose: Constructor for the NANDGate Class and sets the super equal to its desired stats
     */
    public NANDGate(){
        super("NAND Gates" + numGATES, SimpleDiceRoller.roll(NANDGATES_MAX_HP), NANDGATES_ATTACK_DAMAGE, NANDGATES_ARMOR_CLASS);
        numGATES += 1;
    }

    /**
     * Class Name: toString
     * Purpose: returns the string for a NAND Gate
     */
    @Override
    public String toString() {
        return "NAND Gates{} " + super.toString();
    }
}
