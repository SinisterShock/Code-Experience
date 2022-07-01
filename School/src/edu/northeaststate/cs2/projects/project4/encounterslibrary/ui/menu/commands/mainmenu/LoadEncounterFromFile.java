/**
 * -------------------------------------------------
 * File name: LoadEncounterFromFile.java
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

import java.util.Scanner;


/**
 * Class Name: LoadEncounterFromFile implements MenuCommand
 * Class Purpose: LoadEncounterFromFile loads prior encounter data that has been saved to a file back into an encounter
 * ************** object that is instantiated with the LoadEncounterFromFile constructor
 */
public class LoadEncounterFromFile implements MenuCommand {
    private final String COMMAND_NAME = "Load From File";
    private Encounter encounter;

    /**
     * Method Name: LoadEncounterFromFile
     * Method Description: LoadEncounterFromFile constructor has an object name encounter as its parameter which initializes the
     * ******************* current objects encounter object.
     */
    public LoadEncounterFromFile(Encounter encounter) {
        this.encounter = encounter;
    }

    /**
     * Method Name: execute
     * Method Description: execute method asks for the name of the file the user would like to load then uses the
     * ******************* loadFromFile method from the FileAccess class to load the data saved to file by the user previously
     * ******************* then assign the saved data to the current encounter object or returns an exception message
     * ******************* that is caught by the catch statement
     */
    public void execute() {
        try {
            Scanner keyboard = new Scanner(System.in);

            System.out.print("Enter the file name to load: ");

            String filename = keyboard.nextLine().trim();

                FileAccess file = new FileAccess(filename);
                file.loadFromFile(this.encounter);
            } catch (Exception e){
                //System.out.println("\n======================= ERROR ========================");
                System.out.println("\n" + e.getMessage() + "\n");
                //System.out.println("======================================================");
            }
    }

    /**
     * Method Name: isExit
     * Method Description: isExit returns false;
     */
        @Override
        public boolean isExit () {
            return false;
        }

    /**
     * Method Name: getCommandName
     * Method Description: getCommandName returns the value of COMMAND_NAME for the current object;
     */
        @Override
        public String getCommandName () {
            return COMMAND_NAME;
        }
    }