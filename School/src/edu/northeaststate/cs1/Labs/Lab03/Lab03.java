/**
 * ---------------------------------
 * File Name: Lab03.java
 * Project Name: Lab03
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *Creation Date: 9/2/2021
 *----------------------------------
 */
public class Lab03 {
    public static void main(String[] args) {

        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    03                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        // declares and assigns our variables to be used in the printed algorithm
        double velocity0 = 5.6;
        double velocity1 = 10.5;
        double time = 0.5;
        double acceleration = (velocity1 - velocity0)/ time;

        // prints variables
        System.out.println("velocity0 = " + velocity0 + "m/s");
        System.out.println("velocity1 = " + velocity1 + "m/s");
        System.out.println("time = " + time + "s");
        System.out.println("The acceleration is: " + acceleration + "m/s^2");
    }
}
