/**
 * -------------------------------------------------
 * File name: AddOrcs.java
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
import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Orc;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

import java.util.Scanner;

/**
 * Class Name: AddOrcs
 * Purpose: Adds Orcs based on the user input into the encounter list
 */
public class AddOrcs implements MenuCommand {
    private final String COMMAND_NAME = "Add Orcs";
    private Encounter encounter;

    /**
     * Class Name: AddOrcs
     * Purpose: Constructor for AddOrcs
     */
    public AddOrcs(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Class Name: execute
     * Purpose: asks the user how many Orcs they would like to add, adds it to the encounter, prints how many Orcs were added
     */
    @Override
    public void execute() {
        Scanner keyboard = new Scanner(System.in);
        int numOrcsToGenerate = 0;

        System.out.print("Number of Orcs to generate: ");
        numOrcsToGenerate = keyboard.nextInt();

        for (int i = 0; i < numOrcsToGenerate; i++) {
            encounter.addMonster(new Orc());
        }

        System.out.println("Added " +  numOrcsToGenerate + " Orcs.");
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
