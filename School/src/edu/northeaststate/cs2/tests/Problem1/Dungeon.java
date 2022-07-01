package edu.northeaststate.cs2.tests.Problem1;

import java.util.ArrayList;

public class Dungeon {
    private ArrayList<Room> rooms;

    public Dungeon(ArrayList<Room> rooms) {
        this.rooms = rooms;
    }

    public ArrayList<Room> getRooms() {
        return rooms;
    }
}
