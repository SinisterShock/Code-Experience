/**
 * -------------------------------------------
 * File name: Lab02.java
 * Project name: Lab02
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
package edu.northeaststate.cs2.labs.Lab07;

import java.util.ArrayList;
/**
 * Class Name: Lab07
 * Purpose: Use the Compare implementation
 */
public class Lab07 {
    /**
     * Method Name: main
     * Method Description: Entry point to the code
     * @param args
     */
    public static void main(String[] args) {
        ArrayList<Sandwich> sandwiches = new ArrayList<>();
        sandwiches.add(new Sandwich((byte)2, (short)500, 3.50F, "Sausage Biscuit", false));
        sandwiches.add(new Sandwich((byte)2, (short)800, 8.99F, "Philly Cheese Steak", false));
        sandwiches.add(new Sandwich((byte)2, (short)458, 4.99F, "Impossible Burger", true));
        sandwiches.add(new Sandwich((byte)2, (short)560, 4.25F, "BLT", false));
        sandwiches.add(new Sandwich((byte)2, (short)250, 4.62F, "Soy Joy", false));
        System.out.println("Unsorted: ");
        printSandwiches(sandwiches);
        System.out.println("Sorted by name: ");

        //sort the list
        sandwiches.sort(new CompareByName());
        printSandwiches(sandwiches);
        System.out.println("Sorted by cost: ");
        sandwiches.sort(new CompareByCost());
        printSandwiches(sandwiches);
        System.out.println("Sorted by calories: ");
        sandwiches.sort(new CompareByCalories());
        printSandwiches(sandwiches);
        System.out.println("Sorted by Number of Bread Slices: ");
        sandwiches.sort(new CompareByNumBreadSlices());
        printSandwiches(sandwiches);
        System.out.println("Sorted by is vegan: ");
        sandwiches.sort(new CompareByIsVegan());
        printSandwiches(sandwiches);

    }
    /**
     * Method Name: printSandwiches
     * Method Description: for each loop to print each sandwich to the screen
     * @param sandwiches
     */
    public static void printSandwiches(ArrayList<Sandwich> sandwiches){
        for (Sandwich s: sandwiches){
            System.out.println(s);
        }
    }
}
