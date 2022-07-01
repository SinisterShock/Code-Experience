package edu.northeaststate.cs2.projects.project2.monsters;

import edu.northeaststate.cs2.projects.project2.SimpleDiceRoller;

/**
 * Class Name: Imp
 * Purpose: Imp extends Monster and describes a specialization of Monster.
 */
public class Imp extends Monster{
    private static int numImps = 0;
    private static final int IMP_MAX_HP = 62;

    /**
     * Method Name: Imp
     * Method description: Default constructor, creates a name using string literal "Imp " and appends the numImps
     * static attribute. Also uses SimpleDiceRoller to generate a number between 1 and IMPS_MAX_HP.
     * Calls parent constructor using super(). Increments the static variable numImps to count
     * total number of Imps created.
     */
    public Imp(){
        super("Imp " + numImps, SimpleDiceRoller.roll(IMP_MAX_HP));
        numImps += 1;
    }

    public Imp(String name) {
        super(name, SimpleDiceRoller.roll(IMP_MAX_HP));
        numImps += 1;
    }

    public Imp(String name, int hitPoints){
        super(name, hitPoints);
        numImps++;
    }

    @Override
    public String toString() {
        return "Imp [name=" +
                this.name +
                ", hitPoints=" +
                this.hitPoints +
                "]";
    }

}
