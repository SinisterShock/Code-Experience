package edu.northeaststate.cs2.projects.project2.monsters;

import edu.northeaststate.cs2.projects.project2.SimpleDiceRoller;

/**
 * Class Name: Mimic
 * Purpose: Mimic extends Monster and describes a specialization of Monster.
 */
public class Mimic extends Monster{
    private static int numMimic = 0;
    private static final int MIMIC_MAX_HP = 52;

    /**
     * Method Name: Mimic
     * Method description: Default constructor, creates a name using string literal "Mimic " and appends the numMimic
     * static attribute. Also uses SimpleDiceRoller to generate a number between 1 and MIMIC_MAX_HP.
     * Calls parent constructor using super(). Increments the static variable numMimic to count
     * total number of Mimics created.
     */
    public Mimic(){
        super("Mimic " + numMimic, SimpleDiceRoller.roll(MIMIC_MAX_HP));
        numMimic += 1;
    }

    public Mimic(String name) {
        super(name, SimpleDiceRoller.roll(MIMIC_MAX_HP));
        numMimic += 1;
    }

    public Mimic(String name, int hitPoints){
        super(name, hitPoints);
        numMimic++;
    }

    @Override
    public String toString() {
        return "Mimic [name=" +
                this.name +
                ", hitPoints=" +
                this.hitPoints +
                "]";
    }

}