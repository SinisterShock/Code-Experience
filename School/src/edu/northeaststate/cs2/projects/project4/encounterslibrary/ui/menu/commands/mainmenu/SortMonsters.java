package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.mainmenu;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.ConsoleMenu;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.addmonsters.Home;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.sortmonsters.SortByArmorClass;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.sortmonsters.SortByAttackDamage;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.sortmonsters.SortByHitPoints;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.sortmonsters.SortByName;

/**
 * Class Name: SortMonsters
 * Purpose: calls a sort command that organizes the encounter list
 */
public class SortMonsters implements MenuCommand{
    private final String COMMAND_NAME = "Sort Monsters";
    private Encounter encounter;

    /**
     * Class Name: SortMonsters
     * Purpose: constructor for SortMonster
     */
    public SortMonsters(Encounter encounter) {this.encounter = encounter;}

    /**
     * Class Name: execute
     * Purpose: Executes the specified sort command
     */
    @Override
    public void execute() {
        ConsoleMenu menu = new ConsoleMenu(COMMAND_NAME);

        menu.addCommand(new SortByName(this.encounter));
        menu.addCommand(new SortByHitPoints(this.encounter));
        menu.addCommand(new SortByArmorClass(this.encounter));
        menu.addCommand(new SortByAttackDamage(this.encounter));
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
