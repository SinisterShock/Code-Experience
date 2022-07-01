/**
 * -------------------------------------------------
 * File name: Encounter.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course and section: 1020
 * Creation date: Apr 19, 2020
 * -------------------------------------------------
 */
package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import edu.northeaststate.cs2.projects.project4.encounterslibrary.comparators.CompareByArmorClass;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.comparators.CompareByAttackDamage;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.comparators.CompareByHitPoints;
import edu.northeaststate.cs2.projects.project4.encounterslibrary.comparators.CompareByName;

import java.io.Serializable;
import java.util.ArrayList;

public class Encounter implements Serializable {
    private ArrayList<Monster> monsters;

    public Encounter() {
        this.monsters = new ArrayList<>();
    }

    public void addMonster(Monster monster) {
        this.monsters.add(monster);
    }

    public ArrayList<Monster> getMonsters() {
        return monsters;
    }

    public void setMonsters(ArrayList<Monster> monsters) {
        this.monsters = monsters;
    }

    public void sortMonstersByName() {
        this.monsters.sort(new CompareByName());
    }

    public void sortMonstersByHitPoints() {
        this.monsters.sort(new CompareByHitPoints());
    }

    public void sortMonstersByArmorClass(){this.monsters.sort(new CompareByArmorClass());}

    public void sortMonstersByAttackDamage(){this.monsters.sort(new CompareByAttackDamage());}

    @Override
    public String toString() {
        return "Encounter{" +
                "monsters=" + monsters +
                '}';
    }
}
