/**
 * -------------------------------------------
 * File name: Lab02.java
 * Project name: Lab02
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
package edu.northeaststate.cs2.labs.Lab05;
/**
 * Class Name: Lab05
 * Purpose: Uses the item class to compare if objects are equal and what their hash code is
 */
public class Lab05 {
    /**
     * Method Name: main
     * Method Description: main entry point for the code
     * @param args
     */
    public static void main(String[] args) {
        Item item1 = new Item("Hammer of Fate",500);
        Item item2 = new Item("Hammer of Fate",500);
        Item item3 = new Item("Staff of Justice",250);
        Item item4 = new Item("Wand of Doom",360);

        System.out.println("\tPrinting Items");
        System.out.println(item1 + "\n" + item2 + "\n" + item3 + "\n" + item4 + "\n");
        if(item1.equals(item2)){
            System.out.println(item1 + " is equal to " + item2);
            System.out.println(item1.hashCode() + " is equal to " + item2.hashCode() + "\n");
        }else{
            System.out.println(item1 + " is not equal to " + item2);
            System.out.println(item1.hashCode() + " is not equal to " + item2.hashCode() + "\n");
        }
        if(item3.equals(item4)){
            System.out.println(item3 + " is equal to " + item4);
            System.out.println(item3.hashCode() + " is equal to " + item4.hashCode() + "\n");
        }else{
            System.out.println(item3 + " is not equal to " + item4);
            System.out.println(item3.hashCode() + " is not equal to " + item4.hashCode() + "\n");
        }

    }
}
