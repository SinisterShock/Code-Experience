/**
 * -------------------------------------------------
 * File name: AddTrolls.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course: CISP 1020
 * Creation date: Apr 19, 2020
 * -------------------------------------------------
 */

package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.addmonsters;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Troll;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

import java.util.Scanner;

/**
 * Class Name: AddTrolls
 * Purpose: Adds Trolls based on the user input into the encounter list
 */
public class AddTrolls implements MenuCommand {
    private final String COMMAND_NAME = "Add Trolls";
    private Encounter encounter;

    /**
     * Class Name: AddTrolls
     * Purpose: Constructor for AddTrolls
     */
    public AddTrolls(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Class Name: execute
     * Purpose: asks the user how many Trolls they would like to add, adds it to the encounter, prints how many Trolls were added
     */
    @Override
    public void execute() {
        Scanner keyboard = new Scanner(System.in);
        int numTrollsToGenerate = 0;

        System.out.print("Number of Trolls to generate: ");
        numTrollsToGenerate = keyboard.nextInt();

        for (int i = 0; i < numTrollsToGenerate; i++) {
            encounter.addMonster(new Troll());
        }

        System.out.println("Added " +  numTrollsToGenerate + " Trolls.");
    }

    /**
     * Class Name: isExit
     * Purpose: tells the system this is not an exit command
     */
    @Override
    public boolean isExit() {
        return false;
    }

    /**
     * Class Name: getCommandName
     * Purpose: Returns the name of the command being run
     */
    @Override
    public String getCommandName() {
        return COMMAND_NAME;
    }
}
