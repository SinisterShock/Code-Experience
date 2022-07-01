package edu.northeaststate.cs2.labs.Lab07;

import java.util.Comparator;

/**
 * Class Name: Compare
 * Purpose: using the comparator class, compare 2 sandwiches based on their name
 */
public class CompareByName implements Comparator<Sandwich> {

    /**
     * Method Name: compare
     * Method Description: compare 2 sandwiches based on their name
     * @param sandwich1
     * @param sandwich2
     */
    @Override
    public int compare(Sandwich sandwich1, Sandwich sandwich2) {
        return sandwich1.getName().compareTo(sandwich2.getName());
    }
}
