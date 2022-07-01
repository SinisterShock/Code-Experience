package edu.northeaststate.cs2.labs.Lab03;
/**
 * Class Name: Item
 * Purpose: Builds user given input into a string
 */
public class Item {
    private String name;
    private double value;

    /**
     * Method Name: RegularPolygon
     * Method Description: Default Constructor
     */
    public Item(){
        name = "";
        value = 0.0;
    }

    /**
     * Method Name: Item
     * Method Description: Parameterized constructor
     * @param name
     * @param value
     */
    public Item(String name, double value) {
        this.name = name;
        this.value = value;
    }

    /**
     * Method Name: getName
     * Method Description: gets the name of the given item
     */
    public String getName() {
        return name;
    }

    /**
     * Method Name: setName
     * Method Description: sets the name of the given item
     * @param name
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * Method Name: getValue
     * Method Description: gets the value of the given item
     */
    public double getValue() {
        return value;
    }
    /**
     * Method Name: setValue
     * Method Description: sets the value of the given item
     * @param value
     */
    public void setValue(double value) {
        this.value = value;
    }

    /**
     * Method Name: toString
     * Method Description: Uses String builder to push the name and value to a string
     */
    public String toString() {
        final StringBuilder sb = new StringBuilder("Item{");
        sb.append("name='").append(name).append('\'');
        sb.append(", value=").append(value);
        sb.append('}');
        return sb.toString();
    }
}
