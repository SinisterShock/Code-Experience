import java.util.Scanner;

/**
 * ---------------------------------
 * File Name: Lab04.java
 * Project Name: Lab04
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *Creation Date: 9/9/2021
 *----------------------------------
 */

/**
 * Class Name: Lab04
 * Purpose: Demonstrates user input and using input to calculate acceleration
 */
public class Lab04 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    04                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        // sets up variables to be used in user input
        Scanner myScanner = new Scanner(System.in);
        double velocity0 = 0;
        double velocity1 = 0;
        double time = 0;

        // asks the user for desired velocities and time
        System.out.print("Enter a value for velocity0: ");
        velocity0 = myScanner.nextDouble();

        System.out.print("Enter a value for velocity1: ");
        velocity1 = myScanner.nextDouble();

        System.out.print("Enter a value for time: ");
        time = myScanner.nextDouble();

        // sets up formula and prints out acceleration
        double acceleration = (velocity1 - velocity0)/time;
        System.out.println("velocity0 = " + velocity0);
        System.out.println("velocity1 = " + velocity1);
        System.out.println("time = " + time);
        System.out.println("a = " + acceleration + "m/s^2");

    }
}
