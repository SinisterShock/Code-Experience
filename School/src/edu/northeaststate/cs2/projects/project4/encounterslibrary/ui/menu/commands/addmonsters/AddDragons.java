package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.addmonsters;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Dragon;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

import java.util.Scanner;
/**
 * Class Name: AddDragons
 * Purpose: Adds dragons based on the user input into the encounter list
 */
public class AddDragons implements MenuCommand {
    private final String COMMAND_NAME = "Add Dragons";
    private Encounter encounter;

    /**
     * Class Name: AddDragons
     * Purpose: Constructor for AddDragons
     */
    public AddDragons(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Class Name: execute
     * Purpose: asks the user how many dragons they would like to add, adds it to the encounter, prints how many dragons were added
     */
    @Override
    public void execute() {
        Scanner keyboard = new Scanner(System.in);
        int numDragonsToGenerate = 0;

        System.out.print("Number of Dragons to generate: ");
        numDragonsToGenerate = keyboard.nextInt();

        for (int i = 0; i < numDragonsToGenerate; i++) {
            encounter.addMonster(new Dragon());
        }

        System.out.println("Added " +  numDragonsToGenerate + " Dragons.");
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
