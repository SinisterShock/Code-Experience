package edu.northeaststate.cs2.finalexam.problem2;
import java.util.ArrayList;
import java.util.Random;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */

/**
 * Main application for demonstrating inheritance using shapes
 */
public class RandomShapeDriver {
    /**
     * Entry point for the application
     * @param args command line arguments
     */
    public static void main(String[] args) {
        final int NUM_SHAPES = 100; //A constant to control how many random shapes to generate
        ArrayList<Shape> shapes = new ArrayList<>(); //Create an array list of shape objects
        Random random = new Random(); //Create a Random object to get Random numbers
        int randomChoice; //Variable to hold a random into

        //For loop to create NUM_SHAPES Shape objects;
        for (int i = 0; i < NUM_SHAPES; i++) {
            randomChoice = random.nextInt(3);

            switch (randomChoice){
                case 0:
                    shapes.add(new Circle(random.nextInt(10)));
                    break;
                case 1:
                    shapes.add(new Rectangle(random.nextInt(10), random.nextInt(10)));
                    break;
                case 2:
                    shapes.add(new Triangle(random.nextInt(10), random.nextInt(10)));
                    break;
            }
        }

        //Loop through ArrayList and each Shape's toString method
        for (Shape shape : shapes) {
            System.out.println(shape.toString());
        }
    }
}
