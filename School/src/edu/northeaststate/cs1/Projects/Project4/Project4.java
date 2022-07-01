package src.edu.northeaststate.cs1.projects.project4;

import java.text.DecimalFormat;
/**
 * ---------------------------------
 * File Name: Project4.java
 * Project Name: Project4
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */
/**
 * Class Name: Project4
 * Purpose: Using the Rectangle Class to calculate given rectangle parameters
 */
public class Project4 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *
     * @param args not used in this program
     */
    public static void main(String[] args) {
        Rectangle rectangle1 = new Rectangle();
        Rectangle rectangle2 = new Rectangle(4.0, 4.0);
        Rectangle rectangle3 = new Rectangle();
        DecimalFormat dc = new DecimalFormat("###.##");

        rectangle3.setHeight(7.0);
        rectangle3.setWidth(3.5);

        System.out.println("The area of a rectangle with a width " + rectangle1.getWidth() + " and height " + rectangle1.getHeight() + " is " + rectangle1.calculateArea());
        System.out.println("The perimeter of this rectangle is " + rectangle1.calculatePerimeter());
        System.out.println("The diagonal length is: " + dc.format(rectangle1.calculateDiagonal()));
        if(rectangle1.isSquare()){
            System.out.println("This is a square");
        }else {
            System.out.println("This is not a square");
        }

        System.out.println("The area of a rectangle with a width " + rectangle2.getWidth() + " and height " + rectangle2.getHeight() + " is " + rectangle2.calculateArea());
        System.out.println("The perimeter of this rectangle is " + rectangle2.calculatePerimeter());
        System.out.println("The diagonal length is: " + dc.format(rectangle2.calculateDiagonal()));
        if(rectangle2.isSquare()){
            System.out.println("This is a square");
        }else {
            System.out.println("This is not a square");
        }

        System.out.println("The area of a rectangle with a width " + rectangle3.getWidth() + " and height " + rectangle3.getHeight() + " is " + rectangle3.calculateArea());
        System.out.println("The perimeter of this rectangle is " + rectangle3.calculatePerimeter());
        System.out.println("The diagonal length is: " + dc.format(rectangle3.calculateDiagonal()));
        if(rectangle3.isSquare()){
            System.out.println("This is a square");
        }else {
            System.out.println("This is not a square");
        }
    }



}
