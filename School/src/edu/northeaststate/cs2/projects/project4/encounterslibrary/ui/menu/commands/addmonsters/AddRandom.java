package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.addmonsters;


import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.MonsterGenerator;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

/**
 * Class Name: AddDragons
 * Purpose: Adds dragons based on the user input into the encounter list
 */
public class AddRandom implements MenuCommand {
    private final String COMMAND_NAME = "Add Random Monster";
    private Encounter encounter;

    /**
     * Class Name: AddRandom
     * Purpose: Constructor for AddRandom
     */
    public AddRandom(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Class Name: execute
     * Purpose: adds a random monster to the encounter
     */
    @Override
    public void execute() {

        System.out.print("Generating a Random Monster!");

        encounter.addMonster(MonsterGenerator.getRandomMonster());

        System.out.println("Added a mystery monster");
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
