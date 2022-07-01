package edu.northeaststate.cs2.projects.project1;
import java.util.ArrayList;

/**
 * Class Name: Encounter
 * Purpose: Holds an array list from the Monster class and calculates the amount in the list, total health, avg: AC, damage, and hit points
 */
public class Encounter {
    private String name;
    private ArrayList<Monster> monsters;
    /**
     * Method Name: Encounter
     * Method Description: Constructor for Encounter and creates the array list
     * @param name
     */
    public Encounter(String name) {
        this.name = name;
        monsters = new ArrayList<>();
    }

    /**
     * Method Name: getName
     * Method Description: getter for the name
     */
    public String getName() {
        return name;
    }
    /**
     * Method Name: getMonsters
     * Method Description: getter for the monster in the array list
     */
    public ArrayList<Monster> getMonsters() {
        return monsters;
    }

    /**
     * Method Name: addMonster
     * Method Description: adds the inserted monster into the array list using a monster parameter
     * @param monster
     */
    public void addMonster(Monster monster) {
        this.monsters.add(monster);
    }
    /**
     * Method Name: addMonster
     * Method Description: adds the inserted monster into the array list using the name, hitpoints, armorclass, and attackdamage
     * @param name
     * @param hitPoints
     * @param armorClass
     * @param attackDamage
     */
    public void addMonster(String name, int hitPoints, int armorClass, int attackDamage) {
        Monster monster = new Monster(name, hitPoints, armorClass, attackDamage);
        this.monsters.add(monster);

    }
    /**
     * Method Name: calculateTotalMonsters
     * Method Description: returns the amount of monsters in the array list
     */
    public int calculateTotalMonsters() {return monsters.size();}
    /**
     * Method Name: calculateTotalHitPoints
     * Method Description: returns the total hit points of all the monsters
     */
    public int calculateTotalHitPoints() {
        int totalHitPoints = 0;
        if (monsters.size() > 0) {
            for (Monster monster : this.monsters) {
                totalHitPoints += monster.getHitPoints();
            }
        }
        return totalHitPoints;
    }
    /**
     * Method Name: calculateAvgHitPoints
     * Method Description: returns the avg hit points of all the monsters in the array list
     */
    public double calculateAvgHitPoints() {
        double totalHitPoints = 0.0;
        double average = 0.0;
        if (monsters.size() > 0) {
            for (Monster monster : this.monsters) {
                totalHitPoints += monster.getHitPoints();
            }
            average = totalHitPoints / monsters.size();
        }
        return average;
    }
    /**
     * Method Name: calculateAvgHitArmorClass
     * Method Description: returns the avg ArmorClass of all the monsters in the array list
     */
    public double calculateAvgArmorClass() {
        double totalArmorClass = 0.0;
        double average = 0.0;
        if (monsters.size() > 0) {
            for (Monster monster : this.monsters) {
                totalArmorClass += monster.getHitPoints();
            }
            average = totalArmorClass / monsters.size();
        }
        return average;
    }
    /**
     * Method Name: calculateAvgAttackDamage
     * Method Description: returns the avg Attack damage of all the monsters in the array list
     */
    public double calculateAvgAttackDamage(){
        double totalAttackDamage = 0.0;
        double average = 0.0;
        if (this.monsters.size() > 0) {
            for (Monster monster : this.monsters) {
                totalAttackDamage += monster.getHitPoints();
            }
            average = totalAttackDamage / monsters.size();
        }
        return average;
    }

    /**
     * Method Name: toString
     * Method Description: Uses String builder to push the name and value to a string
     */
    public String toString() {
        StringBuilder stringBuilder = new StringBuilder();

        for(Monster monster : this.monsters){
            stringBuilder.append(monster.toString() + "\n");
        }

        return stringBuilder.toString();
    }
}