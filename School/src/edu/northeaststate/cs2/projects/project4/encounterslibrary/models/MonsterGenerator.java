/**
 * -------------------------------------------------
 * File name: MonsterGenerator.java
 * Project Name: Monster Lab!
 * -------------------------------------------------
 * Created By: John McMeen
 * Email: jnmcmeen@northeaststate.edu
 * Course and section: CISP 1020
 * Creation date: Apr 20, 2020
 * -------------------------------------------------
 */
package edu.northeaststate.cs2.projects.project4.encounterslibrary.models;

import java.util.Random;

public class MonsterGenerator {
    public static Monster getRandomMonster() {
        //total type of extended Monsters supported by getRandomMonster
        final int NUM_MONSTER_TYPES = 5;

        //A monster reference to hold our extended Monster
        Monster m = null;

        //Using the Random class to pick a random number
        Random r = new Random();

        //Generate a number 0 to NUM_MONSTER_TYPES exclusive
        int monster_pick = r.nextInt(NUM_MONSTER_TYPES);

        //Switch on monster_pick and return a newly created reference to an extended Monster type
        switch (monster_pick) {
            //monster_pick = 0, then construct an Orc
            case 0:
                m = new Orc(); //upcasting
                break;
            //monster_pick = 1, then construct a Troll
            case 1:
                m = new Troll(); //upcasting
                break;
            case 2:
                m = new Dragon(); //upcasting
                break;
            case 3:
                m = new McBurglar(); //upcasting
                break;
            case 4:
                m = new NANDGate(); //upcasting
                break;
        }

        //Return the randomly decided monster reference
        return m;
    }
}
