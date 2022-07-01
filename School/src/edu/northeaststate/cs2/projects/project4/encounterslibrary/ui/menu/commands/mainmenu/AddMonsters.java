/**
 * -------------------------------------------------
 * File name: AddMonsters.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course: CISP 1020
 * Creation date: Apr 19, 2020
 * -------------------------------------------------
 */

package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.mainmenu;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.ConsoleMenu;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.addmonsters.*;
/**
 * Class Name: AddMonsters
 * Purpose: calls the extended monster and executes its command
 */
public class AddMonsters implements MenuCommand {
    private final String COMMAND_NAME = "Add Monsters";
    private Encounter encounter;

    /**
     * Class Name: AddMonsters
     * Purpose: Constructor for AddMonsters
     */
    public AddMonsters(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Class Name: execute
     * Purpose: Executes the specified add monster command
     */
    @Override
    public void execute() {
        ConsoleMenu menu = new ConsoleMenu(COMMAND_NAME);

        menu.addCommand(new AddDragons(this.encounter));
        menu.addCommand(new AddMcBurglars(this.encounter));
        menu.addCommand(new AddNANDGates(this.encounter));
        menu.addCommand(new AddOrcs(this.encounter));
        menu.addCommand(new AddTrolls(this.encounter));
        menu.addCommand(new AddRandom(this.encounter));
        //TODO You will add the MenuCommand object here for AddRandomMonsters, and an Add Monster MenuCommand for
        // each of your 3 Monster sub classes.(Hint: 4 LOC)

        menu.addCommand(new Home());

        menu.show();
    }

    /**
     * Class Name: isExit
     * Purpose: returns that this is not an exit command
     */
    @Override
    public boolean isExit() {
        return false;
    }

    /**
     * Class Name: getCommandName
     * Purpose: Returns the command name
     */
    @Override
    public String getCommandName() {
        return COMMAND_NAME;
    }
}
