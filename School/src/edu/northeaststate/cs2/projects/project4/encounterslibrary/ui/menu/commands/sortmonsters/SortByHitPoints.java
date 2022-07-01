package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.sortmonsters;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

public class SortByHitPoints implements MenuCommand {
    private final String COMMAND_NAME = "Sort by HitPoints";
    private Encounter encounter;

    public SortByHitPoints(Encounter encounter) {this.encounter = encounter;}

    @Override
    public void execute() {
        System.out.println("Sorting...");
        this.encounter.sortMonstersByHitPoints();
        System.out.println("Monsters sorted by Hitpoints");
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
