package edu.northeaststate.cs2.projects.project2.monsters;

import edu.northeaststate.cs2.projects.project2.SimpleDiceRoller;

/**
 * Class Name: Vampire
 * Purpose: Vampire extends Monster and describes a specialization of Monster.
 */
public class Vampire extends Monster{
    private static int numVampires = 0;
    private static final int VAMPIRE_MAX_HP = 20;

    /**
     * Method Name: Vampire
     * Method description: Default constructor, creates a name using string literal "Vampire " and appends the numVampires
     * static attribute. Also uses SimpleDiceRoller to generate a number between 1 and VAMPIRE_MAX_HP.
     * Calls parent constructor using super(). Increments the static variable numVampire to count
     * total number of Vampires created.
     */
    public Vampire(){
        super("Imp " + numVampires, SimpleDiceRoller.roll(VAMPIRE_MAX_HP));
        numVampires += 1;
    }

    public Vampire(String name) {
        super(name, SimpleDiceRoller.roll(VAMPIRE_MAX_HP));
        numVampires += 1;
    }

    public Vampire(String name, int hitPoints){
        super(name, hitPoints);
        numVampires++;
    }

    @Override
    public String toString() {
        return "Vampire [name=" +
                this.name +
                ", hitPoints=" +
                this.hitPoints +
                "]";
    }

}
