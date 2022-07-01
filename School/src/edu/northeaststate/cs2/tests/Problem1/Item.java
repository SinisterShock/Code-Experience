package edu.northeaststate.cs2.tests.Problem1;

public class Item {
    private String description;
    private int goldPieces;

    public Item(String description, int goldPieces) {
        this.description = description;
        this.goldPieces = goldPieces;
    }

    public String getDescription() {
        return description;
    }

    public int getGoldPieces() {
        return goldPieces;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public void setGoldPieces(int goldPieces) {
        this.goldPieces = goldPieces;
    }
}
