/**
 * ---------------------------------
 * File Name: Lab07.java
 * Project Name: Lab07
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */
import java.util.Scanner;
/**
 * Class Name: Lab07
 * Purpose: Using user input- tell the user how many days are in the month and year they entered
 */
public class Lab07 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *
     * @param args not used in this program
     */
    public static void main(String[] args) {
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐         Lab    07                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");

        Scanner myScanner = new Scanner(System.in);
        int month;
        int year;
        int days = 0;
        String monthName;

        System.out.print("Enter the number of the month(Ex: 1 = January): ");
        month = myScanner.nextInt();
        System.out.print("Enter the year: ");
        year = myScanner.nextInt();
        switch (month) {
            case 1:
                monthName = "January";
                days = 31;
                break;
            case 2:
                monthName = "February";
                if(year % 400 == 0 || (year % 4 == 0 && year % 100 != 0) ) {
                    days = 29;
                } else {
                    days = 28;
                }
                break;
            case 3:
                monthName = "March";
                days = 31;
                break;
            case 4:
                monthName = "April";
                days = 30;
                break;
            case 5:
                monthName = "May";
                days = 31;
                break;
            case 6:
                monthName = "June";
                days = 30;
                break;
            case 7:
                monthName = "July";
                days = 31;
                break;
            case 8:
                monthName = "August";
                days = 31;
                break;
            case 9:
                monthName = "September";
                days = 30;
                break;
            case 10:
                monthName = "October";
                days = 31;
                break;
            case 11:
                monthName = "November";
                days = 30;
                break;
            case 12:
                monthName = "December";
                days = 31;
                break;
            default:
                monthName = "Invalid month Number";
                break;
        }
        System.out.println(monthName + " " + year + " has " + days + " days");

    }
}
