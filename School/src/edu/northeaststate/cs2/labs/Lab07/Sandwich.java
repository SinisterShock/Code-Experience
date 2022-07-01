package edu.northeaststate.cs2.labs.Lab07;

public class Sandwich {
    private byte numBreadSlices;
    private short calories;
    private float cost;
    private String name;
    private boolean isVegan;

    public Sandwich(byte numBreadSlices, short calories, float cost, String name, boolean isVegan) {
        this.numBreadSlices = numBreadSlices;
        this.calories = calories;
        this.cost = cost;
        this.name = name;
        this.isVegan = isVegan;
    }
    // you can hit alt+insert to automatically do the getters and toString method. Constructor, getters, and to string for all
    public byte getNumBreadSlices() {
        return numBreadSlices;
    }

    public short getCalories() {
        return calories;
    }

    public float getCost() {
        return cost;
    }

    public String getName() {
        return name;
    }

    public boolean isVegan() {
        return isVegan;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("Sandwich{");
        sb.append("numBreadSlices=").append(numBreadSlices);
        sb.append(", calories=").append(calories);
        sb.append(", cost=").append(cost);
        sb.append(", name='").append(name).append('\'');
        sb.append(", isVegan=").append(isVegan);
        sb.append('}');
        return sb.toString();
    }
}
