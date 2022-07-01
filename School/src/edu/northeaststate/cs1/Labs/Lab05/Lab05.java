import java.util.Scanner;
/**
 * ---------------------------------
 * File Name: Lab05.java
 * Project Name: Lab05
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *Creation Date: 9/14/2021
 *----------------------------------
 */

/**
 * Class Name: Lab05
 * Purpose: Demonstrates user input and using input in a conversion from celsius to fehrenheit
 */
public class Lab05 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    05                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        // setting up variables
        Scanner myScanner = new Scanner(System.in);
        double celsius = 0;

        // ask user for degrees in celsius
        System.out.print("Enter a degree in Celsius: ");
        celsius = myScanner.nextDouble();
        // create fahrenheit var using new input
        double fahrenheit = (celsius * 9 / 5) + 32;
        // print out results of conversion
        System.out.print("Celsius " + celsius + " is " + fahrenheit + " in Fahrenheit");


    }
}
