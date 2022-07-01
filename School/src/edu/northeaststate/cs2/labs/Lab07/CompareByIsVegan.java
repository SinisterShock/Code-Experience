package edu.northeaststate.cs2.labs.Lab07;

import java.util.Comparator;

/**
 * Class Name: Compare
 * Purpose: using the comparator class, compare 2 sandwiches based on if they're vegan
 */
public class CompareByIsVegan implements Comparator<Sandwich> {
    /**
     * Method Name: compare
     * Method Description: compare 2 sandwiches based on if they're vegan
     * @param sandwich1
     * @param sandwich2
     */
    @Override
    public int compare(Sandwich sandwich1, Sandwich sandwich2) {
        return Boolean.compare(sandwich1.isVegan(), sandwich2.isVegan());
    }
}
