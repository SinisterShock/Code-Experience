package edu.northeaststate.cs2.projects.project2;
import edu.northeaststate.cs2.projects.project2.monsters.Monster;
import java.util.ArrayList;

/**
 * Class Name: Encounter
 * Purpose: Using the monster class it creates an encounter with a name and holds an arraylist of monsters
 */
public class Encounter {
    private ArrayList<Monster> monsters;
    private String name;

    /**
     * Method Name: Encounter
     * Method description: Constructor for encounter
     * @param name
     */
    public Encounter(String name) {
        this.name = name;
        this.monsters = new ArrayList<>();
    }

    /**
     * Method Name: addMonster
     * Method description: Adds a monster to the monsters ArrayList
     * @param monster
     */
    public void addMonster(Monster monster) {
        this.monsters.add(monster);
    }

    /**
     * Method Name: toString
     * Method description: Builds a string to represent Encounter
     * @return String
     */
    @Override
    public String toString() {
        String s = "Encounter[name= " +
                this.name +
                "]\n" +
                "monsters= \n";

        for (int i = 0; i < monsters.size(); i++) {

            s += monsters.get(i).toString() + "\n";
        }

        s += "]";

        return s;
    }

}
