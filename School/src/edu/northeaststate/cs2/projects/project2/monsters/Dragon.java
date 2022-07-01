package edu.northeaststate.cs2.projects.project2.monsters;

import edu.northeaststate.cs2.projects.project2.SimpleDiceRoller;

/**
 * Class Name: Dragon
 * Purpose: Dragon extends Monster and describes a specialization of Monster.
 */
public class Dragon extends Monster{
    private static int numDragons = 0;
    private static final int DRAGON_MAX_HP = 256;

    /**
     * Method Name: Dragon
     * Method description: Default constructor, creates a name using string literal "Dragon " and appends the numDragons
     * static attribute. Also uses SimpleDiceRoller to generate a number between 1 and DRAGONS_MAX_HP.
     * Calls parent constructor using super(). Increments the static variable numDragons to count
     * total number of Dragons created.
     */
    public Dragon(){
        super("Dragon " + numDragons, SimpleDiceRoller.roll(DRAGON_MAX_HP));
        numDragons += 1;
    }

    public Dragon(String name) {
        super(name, SimpleDiceRoller.roll(DRAGON_MAX_HP));
        numDragons += 1;
    }

    public Dragon(String name, int hitPoints){
        super(name, hitPoints);
        numDragons++;
    }

    @Override
    public String toString() {
        return "Dragon [name=" +
                this.name +
                ", hitPoints=" +
                this.hitPoints +
                "]";
    }

}
