package src.edu.northeaststate.cs1.projects.project4;
/**
 * Class Name: Rectangle
 * Purpose: Receive user input and calculate the given parameters when called ex: perimeter
 */
public class Rectangle {
    private double width;
    private double height;
    /**
     * Method Name: Rectangle
     * Method Description: default placeholders for a rectangle
     *
     * @param args not used in this program
     */

    public Rectangle(){
        this.width = 1.0;
        this.height = 1.0;
    }
    /**
     * Method Name: Rectangle
     * Method Description: sets height & width equal to the user input
     *
     * @param newHeight
     * @param newWidth
     */

    public Rectangle(double newWidth, double newHeight){
        width = newWidth;
        height = newHeight;
    }
    /**
     * Method Name: getWidth
     * Method Description: returns the current width stored
     *
     * @param args are not used in this program
     */

    public double getWidth(){return this.width;}
    /**
     * Method Name: setWidth
     * Method Description: sets the given width in place of the default
     *
     * @param newWidth
     */

    public void setWidth(double newWidth){
        this.width = newWidth;
    }
    /**
     * Method Name: getWidth
     * Method Description: returns the current width stored
     *
     * @param args not used in this program
     */

    public double getHeight(){
        return height;
    }
    /**
     * Method Name: setHeight
     * Method Description: sets the given height in place of the default
     *
     * @param newHeight
     */

    public void setHeight(double newHeight){
        this.height = newHeight;
    }
    /**
     * Method Name: calculateArea
     * Method Description: finds the area for a user given rectangle
     *
     * @param args not used in this program
     */

    public double calculateArea(){return width * height;}
    /**
     * Method Name: calculatePerimeter
     * Method Description: finds the perimeter for a user given rectangle
     *
     * @param args not used in this program
     */

    public double calculatePerimeter(){return (2 * width) + (2 * height);}

    public double calculateDiagonal(){return Math.sqrt((Math.pow(width, 2) + Math.pow(height, 2))); }

    public boolean isSquare(){return Double.compare(width, height) == 0;}
}

