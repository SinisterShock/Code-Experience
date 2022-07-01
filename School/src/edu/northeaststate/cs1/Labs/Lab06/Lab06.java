/**
 * ---------------------------------
 * File Name: Lab06.java
 * Project Name: Lab06
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *Creation Date: 9/21/2021
 *----------------------------------
 */
import java.util.Scanner;
/**
 * Class Name: Lab06
 * Purpose: Grade calculator based off score
 */
public class Lab06 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    06                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        Scanner myscanner = new Scanner(System.in);
        int grade;

        System.out.print("Enter a score between 0 and 100: ");
        grade = myscanner.nextInt();

        if(grade < 0 || grade >100) {
            System.out.print("Invalid Input");
            System.exit(0);
        } else{
            if (grade < 65){
                System.out.println(grade + " = F");
                System.exit(0);
            }else if(grade < 70){
                System.out.println(grade + " = D");
                System.exit(0);
            }else if(grade < 80){
                System.out.println(grade + " = C");
                System.exit(0);
            }else if(grade < 90){
                System.out.println(grade + " = B");
                System.exit(0);
            }else{
                System.out.println(grade + " = A");
                System.exit(0);
            }
        }

    }
}
