/**
 * ---------------------------------
 * File Name: Lab10.java
 * Project Name: Lab10
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */
/**
 * Class Name: Lab10
 * Purpose: Dice rolling program using loops
 */
public class Lab10 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    10                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        int diceRoll;
        int total;
        int counter;
        System.out.println("D&D Dice Roller");

        System.out.print("Roll 4d4: ");
        total = 0;
        for (int i = 0; i < 4; i++) {
            diceRoll = rollDice(1,4);
            System.out.print(diceRoll + " ");
            total += diceRoll;
        }
        System.out.println("Total = " + total);

        System.out.print("Roll 6d6: ");
        total = 0;
        for (int i = 0; i < 6; i++) {
            diceRoll = rollDice(1,6);
            System.out.print(diceRoll + " ");
            total += diceRoll;
        }
        System.out.println("Total = " + total);

        total = 0;
        counter = 8;
        System.out.print("Roll 8d8: ");
        while (counter > 0){
            diceRoll = rollDice(1,8);
            System.out.print(diceRoll + " ");
            total += diceRoll;
            counter --;
        }
        System.out.println("Total = " + total);

        total = 0;
        counter = 10;
        System.out.print("Roll 10d10: ");
        while (counter > 0){
            diceRoll = rollDice(1,10);
            System.out.print(diceRoll + " ");
            total += diceRoll;
            counter --;
        }
        System.out.println("Total = " + total);
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
