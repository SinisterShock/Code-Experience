/**
 * ---------------------------------
 * File Name: Lab14.java
 * Project Name: Lab14
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */
/**
 * Class Name: Lab14
 * Purpose: print the sum of the defined 4 columns in a matrix
 */
public class Lab14 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    14                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        double[][] myArray = {
                {1.1, 2.2, 3.3, 4.4},
                {5.5, 6.6, 7.7, 8.8},
                {9.9, 10.10, 11.11, 12.12}
        };
        for (int j = 0; j < myArray[0].length; j++){
            System.out.println("Sum of the elements at column " + j + " is " + sumColumn(myArray, j));
        }

    }
    /**
     * Method Name: sumColumn
     * Method Description: Finds the sum of the entries inside given array and column index
     *
     * @param m
     * @param columnIndex
     */
    public static double sumColumn(double[][] m, int columnIndex) {
        double total = 0;
        for (int i = 0; i < m.length; i++) {
            total += m[i][columnIndex];
        }
        return total;
    }
}
