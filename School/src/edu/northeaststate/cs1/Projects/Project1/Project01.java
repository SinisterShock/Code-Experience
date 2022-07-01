package edu.northeaststate.cs1.projects.project1; /**
 * ------------------------------------
 * File name: edu.northeaststate.cs1.projects.project1.Project01.java
 * Project Name: edu.northeaststate.cs1.projects.project1.Project01
 * ------------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *-------------------------------------
 */


import java.util.Scanner;

/**
 * Class Name: edu.northeaststate.cs1.projects.project1.Project01
 * Purpose: simple wind chill calculator
 */


public class Project01 {
    /**
     * Method Name: main
     * Method Description: entry point for the program
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Project    01              ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        Scanner myScanner = new Scanner(System.in);
        double temperature = 0;
        double windSpeed = 0;

        System.out.print("Enter a value for temperature (F): ");
        temperature = myScanner.nextDouble();
        System.out.print("Enter a value for wind speed (MPH): ");
        windSpeed = myScanner.nextDouble();

        if (temperature < -58){
            System.out.print("Temperature is out of range, must be > -58F and < 70F");
            System.exit(0);
        } else if (temperature > 70){
            System.out.print("Temperature is out of range, must be > -58F and < 70F");
            System.exit(0);
        }else if (windSpeed < 2.0){
            System.out.print("Wind speed is out of range, must be > 2.0 MPH");
            System.exit(0);
        }
            else {
            double windChill = 35.74 + (0.6215 * temperature) - (35.75 * (Math.pow(windSpeed,0.16))) + ((0.4275 * temperature) * (Math.pow(windSpeed,0.16)));
            System.out.println("The wind-chill index is: " + windChill);
        }

    }
}
