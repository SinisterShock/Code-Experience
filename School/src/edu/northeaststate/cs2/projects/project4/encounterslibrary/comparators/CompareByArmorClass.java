package edu.northeaststate.cs2.projects.project4.encounterslibrary.comparators;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Monster;

import java.util.Comparator;
/**
 * Class Name: CompareByArmorClass
 * Purpose: using the comparator class, compare 2 monsters based on their Armor Class
 */
public class CompareByArmorClass implements Comparator<Monster> {
    /**
     * Method Name: compare
     * Method Description: compare 2 monsters based on their Armor Class
     * @param m1
     * @param m2
     */
    @Override
    public int compare(Monster m1, Monster m2) {
        return m1.getArmorClass() - m2.getArmorClass();
    }
}
