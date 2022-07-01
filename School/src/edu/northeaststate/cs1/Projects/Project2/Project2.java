package edu.northeaststate.cs1.projects.project2;
/**
 * ---------------------------------
 * File Name: Project2.java
 * Project Name: Project2
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */
/**
 * Class Name: Project2
 * Purpose: A simple game like "Rock, paper, scissors" where the user plays against the computer
 */
import java.util.Scanner;
/**
 * Method Name: main
 * Method Description: Entry point for program
 *
 * @param args not used in this program
 */
public class Project2 {
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐  Project 2: Batman,Parents,Bad-guy ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");
        Scanner myScanner = new Scanner(System.in);
        int userAnswer;
        int computerAnswer;
        String computerAnswerWritten;
        String userAnswerWritten = "";
        System.out.println("Choose your hand against the computer.\n" +
                            "Batman defeats Bad-Guy\n" +
                            "Bad-Guy defeats Parents\n" +
                            "Parents defeat Batman\n");
        System.out.print("Enter your hand number\n " +
                            "Batman[1], Parents[2], Bad-Guy[3]: ");
        userAnswer = myScanner.nextInt();
        computerAnswer = randomInt(1,3);

        // User's answer choice in a text form
        if(userAnswer > 3 || userAnswer < 1){
            userAnswerWritten = "Invalid";
        }else {
            if(userAnswer == 1){
                userAnswerWritten = "Batman";
            }else if(userAnswer == 2) {
                userAnswerWritten = "Parents";
            }else{
                userAnswerWritten = "Bad-Guy";
            }
        }

        // Computer's answer in a text form
        if(computerAnswer == 1){
            computerAnswerWritten = "Batman";
        }else if(computerAnswer == 2) {
            computerAnswerWritten = "Parents";
        }else{
            computerAnswerWritten = "Bad-Guy";
        }

        // Comparison event
        if(userAnswer > 3 || userAnswer < 1){
            System.out.println("->You entered an invalid hand number");
        } else if(userAnswer == computerAnswer ){
            System.out.println("Computer Hand: " + computerAnswerWritten);
            System.out.println("Player Hand: " + userAnswerWritten);
            System.out.println("-> " + userAnswerWritten + " versus " + computerAnswerWritten + " is a tie!");
        } else if(userAnswer == 1){
            if (computerAnswer == 2) {
                System.out.println("Computer Hand: " + computerAnswerWritten);
                System.out.println("Player Hand: " + userAnswerWritten);
                System.out.println("-> " + computerAnswerWritten + " defeats " + userAnswerWritten + "! Computer Wins!");
            }else{
                System.out.println("Computer Hand: " + computerAnswerWritten);
                System.out.println("Player Hand: " + userAnswerWritten);
                System.out.println("-> " + userAnswerWritten + " defeats " + computerAnswerWritten + "! Player Wins!");
            }
        }else if (userAnswer == 2){
            if (computerAnswer == 3) {
                System.out.println("Computer Hand: " + computerAnswerWritten);
                System.out.println("Player Hand: " + userAnswerWritten);
                System.out.println("-> " + computerAnswerWritten + " defeats " + userAnswerWritten + "! Computer Wins!");
            }else{
                System.out.println("Computer Hand: " + computerAnswerWritten);
                System.out.println("Player Hand: " + userAnswerWritten);
                System.out.println("-> " + userAnswerWritten + " defeats " + computerAnswerWritten + "! Player Wins!");
            }
        }else{
            if (computerAnswer == 1) {
                System.out.println("Computer Hand: " + computerAnswerWritten);
                System.out.println("Player Hand: " + userAnswerWritten);
                System.out.println("-> " + computerAnswerWritten + " defeats " + userAnswerWritten + "! Computer Wins!");
            }else{
                System.out.println("Computer Hand: " + computerAnswerWritten);
                System.out.println("Player Hand: " + userAnswerWritten);
                System.out.println("-> " + userAnswerWritten + " defeats " + computerAnswerWritten + "! Player Wins!");
            }
        }
    }

    /**
     * Method Name: randomInt
     * Method Description: Gets a pseudorandom integer that is >=lower bound and <=upper bound
     *@param upperBound
     * @param lowerBound
     * @return
     */
    public static int randomInt(int lowerBound, int upperBound) {
        int range = (upperBound - lowerBound) + 1;
        int result = (int) (Math.random() * range) + lowerBound;
        return result;
    }
}
