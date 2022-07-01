package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.sortmonsters;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

public class SortByArmorClass implements MenuCommand {
    private final String COMMAND_NAME = "Sort by Armor Class";
    private Encounter encounter;

    public SortByArmorClass(Encounter encounter) {this.encounter = encounter;}

    @Override
    public void execute() {
        System.out.println("Sorting...");
        this.encounter.sortMonstersByArmorClass();
        System.out.println("Monsters sorted by Armor Class");
    }

    @Override
    public boolean isExit() {
        return true;
    }

    @Override
    public String getCommandName() {
        return COMMAND_NAME;
    }
}
