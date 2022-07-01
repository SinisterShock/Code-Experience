/**
 * -------------------------------------------------
 * File name: Monster.java
 * Project Name: D&D Encounters
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course and section: 1020
 * Creation date: Apr 20, 2020
 * -------------------------------------------------
 */
package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import java.io.Serializable;
/**
 * Class Name: Monster
 * Purpose: An abstract class that brings in a monsters name, AC, Attack Damage, and HP
 */
public abstract class Monster implements Serializable {
    protected String name;
    protected int hitPoints;
    protected int attackDamage;
    protected int armorClass;

    /**
     * Class Name: Monster
     * Purpose: Constructor for monster
     */
    public Monster(String name, int hitPoints, int attackDamage, int armorClass) {
        this.name = name;
        this.hitPoints = hitPoints;
        this.attackDamage = attackDamage;
        this.armorClass = armorClass;
    }

    /**
     * Class Name: getName
     * Purpose: returns the name of a monster
     */
    public String getName() {
        return name;
    }

    /**
     * Class Name: getHitPoints
     * Purpose: returns the Hit Points of a monster
     */
    public int getHitPoints() {
        return hitPoints;
    }

    /**
     * Class Name: getAttackDamage
     * Purpose: returns the Attack Damage of a monster
     */
    public int getAttackDamage() {
        return attackDamage;
    }

    /**
     * Class Name: getArmorClass
     * Purpose: returns the Armor Class of a monster
     */
    public int getArmorClass() {
        return armorClass;
    }

    /**
     * Class Name: toString
     * Purpose: returns the string of a monster
     */
    @Override
    public String toString() {
        return "Monster{" +
                "name='" + name + '\'' +
                ", hitPoints=" + hitPoints +
                ", attackDamage=" + attackDamage +
                ", armorClass=" + armorClass +
                '}';
    }
}


