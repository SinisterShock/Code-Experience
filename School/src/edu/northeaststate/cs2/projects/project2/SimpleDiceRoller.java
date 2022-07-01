package edu.northeaststate.cs2.projects.project2;

import java.util.Random;

/**
 * Class Name: SimpleDiceRoller
 * Purpose: Provides methods for rolling dice
 */
public class SimpleDiceRoller {
    /**
     * Method Name: roll
     * Method description: Takes an integer for number of side of "dice." Uses Random class to generate a
     * number between 1 and numSides.
     * @param numSides
     * @return int
     */
    public static int roll(int numSides) {
        Random r = new Random();

        return r.nextInt(numSides) + 1;
    }
}