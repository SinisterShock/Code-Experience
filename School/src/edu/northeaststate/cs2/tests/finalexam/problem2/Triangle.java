package edu.northeaststate.cs2.finalexam.problem2;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */

/**
 * A geometric triangle
 */
public class Triangle extends Shape{
    private double base;
    private double height;

    /**
     * Class constructor specifying height and width of triangle
     * @param base triangle's base in unspecified units
     * @param height triangle's height corresponding to the base is a perpendicular from the base
     *               touching a vertex of the triangle
     */
    public Triangle(double base, double height) {
        this.base = base;
        this.height = height;
    }

    /**
      Calculates the area of the triangle
     * @return calculated area
     */
    @Override
    public double calculateArea() {
        return (base * height) / 2;
    }

    /**
     * Generates a String representation of the triangle
     * @return generated string
     */
    @Override
    public String toString() {
        return "Triangle [" +
                "base=" + base +
                ", height=" + height +
                ", area=" + this.calculateArea() + "]";
    }
}
