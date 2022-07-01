/**
 * ---------------------------------
 * File Name: Lab09.java
 * Project Name: Lab09
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */
/**
 * Class Name: Lab09
 * Purpose: Dice rolling program for d-4,6,8,10,12,20,100
 */
public class Lab09 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    09                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        int diceRoll = 0;
        System.out.println("D&D Dice Roller");
        //Rolls a d4
        diceRoll = rollDice(1,4);
        System.out.println("d4 roll = " + diceRoll);
        //Rolls a d6
        diceRoll = rollDice(1,6);
        System.out.println("d6 roll = " + diceRoll);
        //Rolls a d8
        diceRoll = rollDice(1,8);
        System.out.println("d8 roll = " + diceRoll);
        //Rolls d10
        diceRoll = rollDice(1,10);
        System.out.println("d10 roll = " + diceRoll);
        //Rolls d12
        diceRoll = rollDice(1,12);
        System.out.println("d12 roll = " + diceRoll);
        //Rolls d20
        diceRoll = rollDice(1,20);
        System.out.println("d20 roll = " + diceRoll);
        // Rolls d100
        diceRoll = rollDice(1,100);
        System.out.println("d100 roll = " + diceRoll);
    }

    /**
     * Method Name: rollDice
     * Method Description: Gets a pseudorandom integer that is >=lower bound and < upper bound
     *@param upperBound
     * @param lowerBound
     * @return
     */
    public static int rollDice(int lowerBound, int upperBound) {
        int range = (upperBound - lowerBound) + 1;
        int result = (int) (Math.random() * range) + lowerBound;
        return result;
    }
}
