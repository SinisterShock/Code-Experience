package edu.northeaststate.cs2.tests.Problem1;

public class Monster {
    private String name;
    private int hitpoints;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getHitpoints() {
        return hitpoints;
    }

    public void setHitpoints(int hitpoints) {
        this.hitpoints = hitpoints;
    }

    public Monster(String name, int hitpoints) {
        this.name = name;
        this.hitpoints = hitpoints;
    }
}
