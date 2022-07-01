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
/**
 * Class Name: RegularPolygon
 * Purpose: Recieve user input and calculate the given parameters when called ex: perimeter
 */
public class RegularPolygon {
    private int numsides;
    private double sideLength;
    /**
     * Method Name: setsideLength
     * Method Description: default place holders for a regular polygon
     *
     * @param args not used in this program
     */
    public RegularPolygon(){
        this.numsides = 3;
        this.sideLength = 1.0;
    }
    /**
     * Method Name: RegularPolygon
     * Method Description: sets numsides & sidelength equal to the user input
     *
     * @param length
     * @param sides
     */
    public RegularPolygon(int sides, double length){
        numsides = sides;
        sideLength = length;
    }
    /**
     * Method Name: getNumSide
     * Method Description: returns the current number of sides stored
     *
     * @param args are not used in this program
     */
    public int getNumSides(){
        return this.numsides;
    }
    /**
     * Method Name: setNumSides
     * Method Description: sets the given number of sides in place of the default
     *
     * @param sides
     */
    public void setNumSides(int sides){
        this.numsides =sides;
    }
    /**
     * Method Name: getsideLength
     * Method Description: returns the current side length stored
     *
     * @param args not used in this program
     */
    public double getSideLength(){
        return sideLength;
    }
    /**
     * Method Name: setsideLength
     * Method Description: sets the given Side length in place of the default
     *
     * @param length
     */
    public void setSideLength(double length){
        this.sideLength = length;
    }
    /**
     * Method Name: calculateArea
     * Method Description: finds the area for a user given polygon
     *
     * @param args not used in this program
     */
    public double calculateArea(){
        return numsides * sideLength * sideLength / (4 * Math.tan(Math.PI / numsides));
    }
    /**
     * Method Name: calculatePerimeter
     * Method Description: finds the perimeter for a user given polygon
     *
     * @param args not used in this program
     */
    public double calculatePerimeter(){
        return sideLength * numsides;
    }
}
