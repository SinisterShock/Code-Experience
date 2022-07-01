package edu.northeaststate.cs2.tests.Problem1;

import java.util.ArrayList;

public class Room {
    private ArrayList<Monster> baddies;
    private ArrayList<TreasureChest> treasureChests;
    private ArrayList<Item> items;

    public Room(ArrayList<Monster> baddies, ArrayList<TreasureChest> treasureChests, ArrayList<Item> items) {
        this.baddies = baddies;
        this.treasureChests = treasureChests;
        this.items = items;
    }

    public ArrayList<Monster> getBaddies() {
        return baddies;
    }

    public ArrayList<TreasureChest> getTreasureChests() {
        return treasureChests;
    }

    public ArrayList<Item> getItems() {
        return items;
    }
}
