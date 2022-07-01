/**
 * -------------------------------------------
 * File name: Lab02.java
 * Project name: Lab02
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
package edu.northeaststate.cs2.labs.Lab02;
import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;
/**
 * Class Name: Lab02
 * Purpose:Using the Item class to print and select a random item from a user inputted array list
 */
public class Lab02 {
    /**
     * Method Name: main
     * Method Description: main entry point for the code
     * @param args
     */
    public static void main(String[] args) {
        Scanner myScanner = new Scanner(System.in);
        ArrayList<Item> itemArray = new ArrayList();
        Random random = new Random();
        Item item;
        String tempName = "";
        double tempValue = 0.0;

        while(!tempName.equalsIgnoreCase("quit")){
            System.out.print("Enter Item Name: ");
            tempName = myScanner.nextLine();
            if (!tempName.equalsIgnoreCase("quit")) {
                System.out.print("Enter Item Value: ");
                tempValue = myScanner.nextDouble();
                myScanner.nextLine(); // Flushing Buffer


                item = new Item(tempName, tempValue);
                itemArray.add(item);
            }
        }

        System.out.println("\tPrinting Items");

        for (int i = 0; i < itemArray.size(); i++) {
            System.out.println(itemArray.get(i));
        }

        System.out.println("\tPicking Random Item");

        int size = itemArray.size();
        int randomIndex = random.nextInt(size);
        System.out.println(itemArray.get(randomIndex));

    }
}
