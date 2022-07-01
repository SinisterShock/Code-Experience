package edu.northeaststate.cs2.finalexam.problem2;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */

/**
 * A geometric circle
 */
public class Circle extends Shape{
    private double radius;

    /**
     * Class constructor specifying radius of circle
     * @param radius circle's radius in unspecified units
     */
    public Circle(double radius) {
        this.radius = radius;
    }

    /**
     * Calculates the area of the circle
     * @return calculated area
     */
    @Override
    public double calculateArea() {
        return Math.PI * Math.pow(radius, 2);
    }

    /**
     * Generates a String representation of the circle
     * @return generated string
     */
    @Override
    public String toString() {
        return "Circle [" +
                "radius=" + radius +
                ", area=" + this.calculateArea() + "]";
    }
}
