/**
 * -------------------------------------------------
 * File name: EncounterGen.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: Tyler Burleson, Paul Basler
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020
 * Due date: Apr 29, 2022
 * -------------------------------------------------
 */

package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.ConsoleMenu;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.mainmenu.*;
/**
 * Class Name: EncounterGen
 * Purpose: Encounter Driver for the monster Lab
 */
public class EncounterGen {
    /**
     * Class Name: main
     * Purpose: entry point for the code
     */
    public static void main(String[] args) {
        final String MENU_NAME = "MONSTER LAB! Encounter Manager\n" +
                                 "------------------------------";

        Encounter encounter = new Encounter();

        ConsoleMenu menu = new ConsoleMenu(MENU_NAME);

        //TODO add MenuCommand objects to menu, for load, save, and sort commands (Hint 3 LOC)
        menu.addCommand(new AddMonsters(encounter));
        menu.addCommand(new ShowAllMonsters(encounter));
        menu.addCommand(new SortMonsters(encounter));
        menu.addCommand(new SaveEncounterToFile(encounter));
        menu.addCommand(new LoadEncounterFromFile(encounter));
        menu.addCommand(new Exit()); 

        menu.show();
    }
}
