package edu.northeaststate.cs2.labs.Lab01;

/**
 * -------------------------------------------
 * File name: Lab01.java
 * Project name: Lab01
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */


/**
 * Class Name: Lab01
 * Purpose:Using a regularPolygon object for 3 polygons
 */
public class Lab01 {
    /**
     * Method Name: main
     * Method Description: main entry point for the code
     * @param args
     */
    public static void main(String[] args) {
        RegularPolygon regularPolygon1 = new RegularPolygon();
        RegularPolygon regularPolygon2 = new RegularPolygon(3, 8);
        RegularPolygon regularPolygon3 = new RegularPolygon();

        regularPolygon3.setNumSides(2);
        regularPolygon3.setSideLength(1.25);

        System.out.println(
                "Regular Polygon 1:" + "\n" + "Number of sides: " + regularPolygon1.getNumSides() + "\n"
        + "Side Length: " + regularPolygon1.getSideLength() + "\n"
        + "Perimeter: " + regularPolygon1.calculatePerimeter() + "\n"
        + "Area: " + regularPolygon1.calculateArea() + "\n");

        System.out.println(
                "Regular Polygon 2:" + "\n" + "Number of sides: " + regularPolygon2.getNumSides() + "\n"
                        + "Side Length: " + regularPolygon2.getSideLength() + "\n"
                        + "Perimeter: " + regularPolygon2.calculatePerimeter() + "\n"
                        + "Area: " + regularPolygon2.calculateArea() + "\n");

        System.out.println(
                "Regular Polygon 3:" + "\n" + "Number of sides: " + regularPolygon3.getNumSides() + "\n"
                        + "Side Length: " + regularPolygon3.getSideLength() + "\n"
                        + "Perimeter: " + regularPolygon3.calculatePerimeter() + "\n"
                        + "Area: " + regularPolygon3.calculateArea() + "\n");
    }
}
