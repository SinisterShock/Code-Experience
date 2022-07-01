/**
 * -------------------------------------------------
 * File name: Troll.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course and section: 1020
 * Creation date: Apr 5, 2020
 * -------------------------------------------------
 */
package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import edu.northeaststate.cs2.projects.project4.util.SimpleDiceRoller;

import java.io.Serializable;

/**
 * Class Name: Troll
 * Purpose: An extension of the monster class as a Troll
 */
public class Troll extends Monster implements Serializable {
    private static int numTrolls = 1;
    private static final int TROLL_MAX_HP = 120;
    private static final int TROLL_ATTACK_DAMAGE = 12;
    private static final int TROLL_ARMOR_CLASS = 13;

    /**
     * Class Name: Troll
     * Purpose: Constructor for the Troll Class and sets the super equal to its desired stats
     */
    public Troll() {
        super("Troll " + numTrolls, SimpleDiceRoller.roll(TROLL_MAX_HP), TROLL_ATTACK_DAMAGE, TROLL_ARMOR_CLASS);
        numTrolls += 1;
    }

    /**
     * Class Name: toString
     * Purpose: returns the string for a Troll
     */
    @Override
    public String toString() {
        return "Troll{} " + super.toString();
    }
}
