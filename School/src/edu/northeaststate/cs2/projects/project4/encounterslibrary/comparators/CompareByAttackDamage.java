package edu.northeaststate.cs2.projects.project4.encounterslibrary.comparators;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.models.Monster;

import java.util.Comparator;
/**
 * Class Name: CompareByAttackDamage
 * Purpose: using the comparator class, compare 2 monsters based on their Attack Damage
 */
public class CompareByAttackDamage implements Comparator<Monster> {
    /**
     * Method Name: compare
     * Method Description: compare 2 monsters based on their Attack Damage
     * @param m1
     * @param m2
     */
    @Override
    public int compare(Monster m1, Monster m2) {
        return m1.getAttackDamage() - m2.getAttackDamage();
    }
}
