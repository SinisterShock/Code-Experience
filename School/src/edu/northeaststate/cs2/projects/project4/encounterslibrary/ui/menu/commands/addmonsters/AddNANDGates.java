package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.addmonsters;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.NANDGate;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

import java.util.Scanner;

/**
 * Class Name: AddNANDGates
 * Purpose: Adds NANDGates based on the user input into the encounter list
 */
public class AddNANDGates implements MenuCommand {
    private final String COMMAND_NAME = "Add NAND Gates";
    private Encounter encounter;

    /**
     * Class Name: AddNANDGates
     * Purpose: Constructor for AddNANDGates
     */
    public AddNANDGates(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Class Name: execute
     * Purpose: asks the user how many NANDGates they would like to add, adds it to the encounter, prints how many NANDGates were added
     */
    @Override
    public void execute() {
        Scanner keyboard = new Scanner(System.in);
        int numNANDGATESToGenerate = 0;

        System.out.print("Number of NAND Gates to generate: ");
        numNANDGATESToGenerate = keyboard.nextInt();

        for (int i = 0; i < numNANDGATESToGenerate; i++) {
            encounter.addMonster(new NANDGate());
        }

        System.out.println("Added " +  numNANDGATESToGenerate + " NAND Gates.");
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
