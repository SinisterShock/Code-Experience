/**
 * -------------------------------------------------
 * File name: FileAccess.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen - Updated By: Paul Basler
 * Email: jnmcmeen@northeaststate.edu
 * Course: CISP 1020
 * Creation date: Apr 19, 2020 - Updated date: April 24, 2022
 * -------------------------------------------------
 */
package edu.northeaststate.cs2.projects.project4.encounterslibrary.data;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Encounter;

import java.io.File;
import java.io.FileOutputStream;
import java.io.ObjectOutputStream;
import java.io.ObjectInputStream;
import java.io.FileInputStream;

import java.io.IOException;

/**
 * Class Name: FileAccess
 * Class Purpose: FileAccess creates a saveToFile and loadFromFile methods that can process an Encounter object
 * ************** by either saving it to a text file or by loading data from a text file
 */
public class FileAccess {
    //TODO abstraction
        private String filename;

    /**
     * Method Name: FileAccess
     * Method Description: FileAccess initializes the filename value of the current object with the filename provided by
     * ******************* the user
     */
        public FileAccess(String filename) {
            this.filename = filename;
        }

    /**
     * Method Name: saveToFile
     * Method Description: saveToFile has a parameter of the value encounter that is parsed and saved to a text file that
     * ******************* uses the filename provided by the user
     */
        public void saveToFile(Encounter encounter) throws IOException {
            File file = new File(this.filename);
            String abs = file.getAbsolutePath();
            FileOutputStream fos = new FileOutputStream(abs);
            ObjectOutputStream oos = new ObjectOutputStream(fos);
            oos.writeObject(encounter);
            System.out.println("\nFile saved to: " + file.getAbsolutePath());
            oos.close();
        }

    /**
     * Method Name: loadFromFile
     * Method Description: loadFromFile has a parameter of the value encounter the file selected by user is parsed by the
     * ******************* readObject method and assigned to the encounter object using the setMonsters method
     */
        public void loadFromFile(Encounter encounter) throws IOException, ClassNotFoundException {
            ObjectInputStream input = new ObjectInputStream(new FileInputStream(this.filename));

            Encounter temp = (Encounter) input.readObject();

            encounter.setMonsters(temp.getMonsters());

            input.close();
        }
    }