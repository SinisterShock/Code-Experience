package edu.northeaststate.cs2.labs.Lab07;

import java.util.Comparator;
/**
 * Class Name: Compare
 * Purpose: using the comparator class, compare 2 sandwiches based on their calories
 */
public class CompareByCalories implements Comparator<Sandwich> {

    /**
     * Method Name: compare
     * Method Description: compare 2 sandwiches based on their calories
     * @param sandwich1
     * @param sandwich2
     */
    @Override
    public int compare(Sandwich sandwich1, Sandwich sandwich2) {
        return Short.compare(sandwich1.getCalories(), sandwich2.getCalories());
    }
}
