/**
 * -------------------------------------------------
 * File name: SaveEncounterToFile.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: Paul Basler
 * Email: jnmcmeen@northeaststate.edu
 * Course: CISP 1020
 * Creation date: Apr 19, 2022
 * -------------------------------------------------
 */

package edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.mainmenu;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.data.FileAccess;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.ui.menu.commands.MenuCommand;

import java.io.IOException;
import java.util.Scanner;

/**
 * Class Name: SaveEncounterToFile implements MenuCommand
 * Class Purpose: SaveEncounterToFile takes the encounter data that has been collected from the user then uses the
 * ************** FileAccess, and Scanner objects to save the data to My_File.txt with the name of the file being provided
 * ************** by the user through the use of the Scanner object.
 */
public class SaveEncounterToFile implements MenuCommand {
    private final String COMMAND_NAME = "Save To File";
    private Encounter encounter;

    /**
     * Method Name: SaveEncounterToFile
     * Method Description: SaveEncounterToFile constructor has an object name encounter as its parameter which initializes the
     * ******************* current objects encounter object.
     */
    public SaveEncounterToFile(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Method Name: execute
     * Method Description: execute method asks for the name the user wants the file to be then uses the saveToFile method
     * ******************* from the FileAccess class to save the data created by the user to a .txt file by the name
     * ******************* provided by the user or returns a File save error message if an exception is caught by the
     * ******************* catch statement
     */
    public void execute()  {
        Scanner keyboard = new Scanner(System.in);

        System.out.print("Enter file name to save: ");
        String filename = keyboard.nextLine().trim();
        try {
            FileAccess file = new FileAccess(filename);
            file.saveToFile(this.encounter);
            System.out.println("\n\nFile saved.");
        } catch (IOException e) {
            System.out.println("File save error.");
            System.out.println(e.getMessage());
        }
    }

    /**
     * Method Name: isExit
     * Method Description: isExit returns false;
     */
    @Override
    public boolean isExit() {
        return false;
    }

    /**
     * Method Name: getCommandName
     * Method Description: getCommandName returns the value of COMMAND_NAME for the current object;
     */
    @Override
    public String getCommandName() {
        return COMMAND_NAME;
    }
}
