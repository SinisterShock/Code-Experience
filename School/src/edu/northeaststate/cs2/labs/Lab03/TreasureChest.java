package edu.northeaststate.cs2.labs.Lab03;
import java.util.ArrayList;
import java.util.Random;

/**
 * Class Name: TreasureChest
 * Purpose: Holds an array list from the Item class and returns the amount of items, average of items, and a random item
 */
public class TreasureChest {
    private ArrayList<Item> items;

    /**
     * Method Name: TreasureChest
     * Method Description: Constructor for treasure chest and creates a new array list
     */
    public TreasureChest() {
        items = new ArrayList<>();
    }
    /**
     * Method Name: getItems
     * Method Description: Getter for items
     */
    public ArrayList<Item> getItems() {
        return items;
    }
    /**
     * Method Name: getNumItems
     * Method Description: Returns an integer of how many items are in the array list
     */
    public int getNumItems() {
        return items.size();
    }
    /**
     * Method Name: getAvgValueOfItems
     * Method Description: Finds the average value of all items in the array
     */
    public double getAvgValueOfItems(){
        double totalValue = 0.0;
        double average = 0.0;
        if(items.size() > 0) {
            for (Item item : this.items) {
                totalValue += item.getValue();
            }
            average = totalValue / items.size();
        }
        return average;
    }

    /**
     * Method Name: addItem
     * Method Description: adds an item to the array list
     */
    public void addItem(Item item){
        this.items.add(item);
    }

    /**
     * Method Name: getRandomItem
     * Method Description: Using the random class, returns a random item from the array list
     */
    public Item getRandomItem(){
        Random random = new Random();
        Item item = null;

        if(items.size() > 0){
            item = items.get(random.nextInt(items.size()));
        }

        return item;
    }

    /**
     * Method Name: toString
     * Method Description: Uses String builder to push the name and value to a string
     */
    public String toString() {
        StringBuilder stringBuilder = new StringBuilder();

        for(Item item : this.items){
            stringBuilder.append(item.toString() + "\n");
        }

        return stringBuilder.toString();
    }
}
