/**
 * -------------------------------------------------
 * File name: CompareByName.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course: CISP 1020
 * Creation date: Apr 19, 2020
 * -------------------------------------------------
 */
package edu.northeaststate.cs2.projects.project4.encounterslibrary.comparators;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Monster;

import java.util.Comparator;
/**
 * Class Name: CompareByName
 * Purpose: using the comparator class, compare 2 monsters based on their name
 */
public class CompareByName implements Comparator<Monster> {
    /**
     * Method Name: compare
     * Method Description: compare 2 monsters based on their name
     * @param m1
     * @param m2
     */
    @Override
    public int compare(Monster m1, Monster m2) {
        return m1.getName().compareTo(m2.getName());
    }
}
