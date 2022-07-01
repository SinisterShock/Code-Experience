package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.addmonsters;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.McBurglar;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

import java.util.Scanner;

/**
 * Class Name: AddMcBurglars
 * Purpose: Adds McBurglars based on the user input into the encounter list
 */
public class AddMcBurglars implements MenuCommand {
    private final String COMMAND_NAME = "Add McBurglars";
    private Encounter encounter;

    /**
     * Class Name: AddMcBurglars
     * Purpose: Constructor for AddMcBurglars
     */
    public AddMcBurglars(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Class Name: execute
     * Purpose: asks the user how many McBurglars they would like to add, adds it to the encounter, prints how many McBurglars were added
     */
    @Override
    public void execute() {
        Scanner keyboard = new Scanner(System.in);
        int numMcBurglarsToGenerate = 0;

        System.out.print("Number of McBurglars to generate: ");
        numMcBurglarsToGenerate = keyboard.nextInt();

        for (int i = 0; i < numMcBurglarsToGenerate; i++) {
            encounter.addMonster(new McBurglar());
        }

        System.out.println("Added " +  numMcBurglarsToGenerate + " McBruglars.");
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
