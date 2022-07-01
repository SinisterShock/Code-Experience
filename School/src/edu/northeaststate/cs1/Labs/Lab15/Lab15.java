/**
 * ---------------------------------
 * File Name: Lab15.java
 * Project Name: Lab15
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */

import java.text.DecimalFormat;

/**
 * Class Name: Lab15
 * Purpose: Using the Regular Polygon Class to calculate given regular polygon parameters
 */
public class Lab15 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *
     * @param args not used in this program
     */
    public static void main(String[] args) {
       RegularPolygon regularPolygon1 = new RegularPolygon();
       RegularPolygon regularPolygon2 = new RegularPolygon(6, 4.0);
       RegularPolygon regularPolygon3 = new RegularPolygon();
        DecimalFormat dc = new DecimalFormat("###.##");

       regularPolygon3.setNumSides(12);
       regularPolygon3.setSideLength(1.25);

        System.out.println("Polygon 1 number of sides: " + regularPolygon1.getNumSides());
        System.out.println("Polygon 1 side length: " + regularPolygon1.getSideLength());
        System.out.println("Polygon 1 perimeter: " + regularPolygon1.calculatePerimeter());
        System.out.println("Polygon 1 area: " + dc.format(regularPolygon1.calculateArea()));
        System.out.println();

        System.out.println("Polygon 2 number of sides: " + regularPolygon2.getNumSides());
        System.out.println("Polygon 2 side length: " + regularPolygon2.getSideLength());
        System.out.println("Polygon 2 perimeter: " + regularPolygon2.calculatePerimeter());
        System.out.println("Polygon 2 area: " + dc.format(regularPolygon2.calculateArea()));
        System.out.println();

        System.out.println("Polygon 3 number of sides: " + regularPolygon3.getNumSides());
        System.out.println("Polygon 3 side length: " + regularPolygon3.getSideLength());
        System.out.println("Polygon 3 perimeter: " + regularPolygon3.calculatePerimeter());
        System.out.println("Polygon 3 area: " + dc.format(regularPolygon3.calculateArea()));
    }
}
