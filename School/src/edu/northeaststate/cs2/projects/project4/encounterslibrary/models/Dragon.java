package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import edu.northeaststate.cs2.projects.project4.util.SimpleDiceRoller;

import java.io.Serializable;
/**
 * Class Name: Dragon
 * Purpose: An extension of the monster class as a Dragon
 */
public class Dragon  extends Monster implements Serializable {
    private static int numDragons = 1;
    private static final int DRAGON_MAX_HP = 500;
    private static final int DRAGON_ATTACK_DAMAGE = 35;
    private static final int DRAGON_ARMOR_CLASS = 17;

    /**
     * Class Name: Dragon
     * Purpose: Constructor for the Dragon Class and sets the super equal to its desired stats
     */
    public Dragon(){
        super("Dragon" + numDragons, SimpleDiceRoller.roll(DRAGON_MAX_HP), DRAGON_ATTACK_DAMAGE, DRAGON_ARMOR_CLASS);
        numDragons += 1;
    }
    /**
     * Class Name: toString
     * Purpose: returns the string for a dragon
     */
    @Override
    public String toString() {
        return "Dragon{} " + super.toString();
    }
}
