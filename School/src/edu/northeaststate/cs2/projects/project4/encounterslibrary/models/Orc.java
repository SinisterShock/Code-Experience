/**
 * -------------------------------------------------
 * File name: Orc.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course and section: 1020
 * Creation date: Apr 20, 2020
 * -------------------------------------------------
 */
package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import edu.northeaststate.cs2.projects.project4.util.SimpleDiceRoller;

import java.io.Serializable;

/**
 * Class Name: Orc
 * Purpose: An extension of the monster class as an Orc
 */
public class Orc extends Monster implements Serializable {
    private static int numOrcs = 1;
    private static final int ORC_MAX_HP = 22;
    private static final int ORC_ATTACK_DAMAGE = 12;
    private static final int ORC_ARMOR_CLASS = 14;

    /**
     * Class Name: Orc
     * Purpose: Constructor for the Orc Class and sets the super equal to its desired stats
     */
    public Orc() {
        super("Orc " + numOrcs, SimpleDiceRoller.roll(ORC_MAX_HP), ORC_ATTACK_DAMAGE, ORC_ARMOR_CLASS);
        numOrcs += 1;
    }

    /**
     * Class Name: toString
     * Purpose: returns the string for an Orc
     */
    @Override
    public String toString() {
        return "Orc{} " + super.toString();
    }
}
