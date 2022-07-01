package edu.northeaststate.cs2.labs.Lab01;
/**
 * Class Name: RegularPolygon
 * Purpose: Calculates the perimeter and area of a regular polygon from given number of sides and side length
 */
public class RegularPolygon {
    private int numSides;
    private double sideLength;

    public RegularPolygon() {
        numSides = 3;
        sideLength = 1;
    }

    /**
     * Method Name: RegularPolygon
     * Method Description: constructor for the RegularPolygon class
     * @param sides
     * @param length
     */
    public RegularPolygon(int sides, double length) {

        numSides = sides;
        sideLength = length;
    }
    /**
     * Method Name: getNumSides
     * Method Description: gets the number of sides on the given regular polygon
     */
    public int getNumSides() {
        return numSides;
    }
    /**
     * Method Name: getSideLength
     * Method Description: gets the length of the sides on the given regular polygon
     */
    public double getSideLength() {
        return sideLength;
    }
    /**
     * Method Name: setNumSides
     * Method Description: sets the number of sides on the given regular polygon
     * @param sides
     */
    public void setNumSides(int sides) {
        this.numSides = sides;
    }
    /**
     * Method Name: setSideLength
     * Method Description: sets the length of the sides on the given regular polygon
     * @param length
     */
    public void setSideLength(double length) {
        this.sideLength = length;
    }
    /**
     * Method Name: calculateArea
     * Method Description: Calculates the area of the given regular polygon
     * @param args not used in this method
     *
     */
    public double calculateArea(){return numSides * (Math.pow(sideLength,2))/(4 * Math.tan(Math.PI/numSides));}
    /**
     * Method Name: calculatePerimeter
     * Method Description: Calculates the perimeter of the given regular polygon
     * @param args not used in this method
     */
    public double calculatePerimeter(){return numSides * sideLength;}

}
