package edu.northeaststate.cs2.projects.project2.monsters;

import edu.northeaststate.cs2.projects.project2.SimpleDiceRoller;

/**
 * Class Name: Kobold
 * Purpose: Kobold extends Monster and describes a specialization of Monster.
 */
public class Kobold extends Monster{
    private static int numKobolds = 0;
    private static final int KOBOLD_MAX_HP = 62;

    /**
     * Method Name: Kobold
     * Method description: Default constructor, creates a name using string literal "Kobold " and appends the numKobolds
     * static attribute. Also uses SimpleDiceRoller to generate a number between 1 and KOBOLD_MAX_HP.
     * Calls parent constructor using super(). Increments the static variable numKobolds to count
     * total number of Kobolds created.
     */
    public Kobold(){
        super("Kobold " + numKobolds, SimpleDiceRoller.roll(KOBOLD_MAX_HP));
        numKobolds+= 1;
    }

    public Kobold(String name) {
        super(name, SimpleDiceRoller.roll(KOBOLD_MAX_HP));
        numKobolds += 1;
    }

    public Kobold(String name, int hitPoints){
        super(name, hitPoints);
        numKobolds++;
    }

    @Override
    public String toString() {
        return "Kobold [name=" +
                this.name +
                ", hitPoints=" +
                this.hitPoints +
                "]";
    }

}
