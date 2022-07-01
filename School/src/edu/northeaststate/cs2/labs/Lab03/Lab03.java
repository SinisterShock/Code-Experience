package edu.northeaststate.cs2.labs.Lab03;
import java.util.Scanner;
/**
 * -------------------------------------------
 * File name: Lab03.java
 * Project name: Lab03
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */

/**
 * Class Name: Lab03
 * Purpose:Using the Item class to print and select a random item from a user inputted array list
 */
public class Lab03 {
    /**
     * Method Name: main
     * Method Description: main entry point for the code
     * @param args
     */
    public static void main(String[] args) {
        Scanner myScanner = new Scanner(System.in);
        Item item;
        String tempName = "";
        double tempValue = 0.0;
        TreasureChest chest = new TreasureChest();

        while(!tempName.equalsIgnoreCase("quit")){
            System.out.print("Enter Item Name: ");
            tempName = myScanner.nextLine();

            if (!tempName.equalsIgnoreCase("quit")) {
                System.out.print("Enter Item Value: ");
                tempValue = myScanner.nextDouble();
                myScanner.nextLine(); // Flushing Buffer
                chest.addItem( new Item(tempName, tempValue));
            }
        }

        System.out.println("\n\tPrinting Treasure Chest Items");
        if (chest.getNumItems() > 0){
            System.out.println(chest);

            System.out.println("\tPicking Random Item");
            System.out.println(chest.getRandomItem().toString());

            System.out.println("\nTotal Number of Items = " + chest.getNumItems());
            System.out.println("Avg Value of Items = " + chest.getAvgValueOfItems() + " Gold");
        }else{
            System.out.println("the chest is empty");
        }




    }


}
