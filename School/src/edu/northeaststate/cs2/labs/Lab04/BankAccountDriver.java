/**
 * -------------------------------------------
 * File name: Lab04.java
 * Project name: Lab04
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
package edu.northeaststate.cs2.labs.Lab04;
/**
 * Class Name: BankAccountDriver
 * Purpose: Demonstrate Try/Catch in the BankAccount.java
 */
public class BankAccountDriver {
    /**
     * Method Name: main
     * Method Description: Entry point for the application
     * @param args command line arguments
     */
    public static void main(String[] args) {
        System.out.println("Dollar Bank Online");
        BankAccount account = new BankAccount();

        System.out.println("Depositing 500");
        try {
            account.deposit(500);
        } catch (BankExceptions e) {
            e.getMessage();
        }
        System.out.println("New balance: " + account.getBalance());

        System.out.println("Depositing -1.0");
        try {
            account.deposit(-1);
        } catch (BankExceptions e ) {
            System.out.println(e.getMessage());

        }
        System.out.println("New balance: " + account.getBalance());

        System.out.println("Withdrawing 501.0");
        try {
            account.withdraw(501.0);
        } catch (BankExceptions e ) {
            System.out.println(e.getMessage());

        }
        System.out.println("New balance: " + account.getBalance());

        System.out.println("Withdrawing 0.0");
        try {
            account.withdraw(0);
        } catch (BankExceptions e ) {
            System.out.println(e.getMessage());

        }
        System.out.println("New balance: " + account.getBalance());

        System.out.println("Withdrawing 500");
        try {
            account.withdraw(500);
        } catch (BankExceptions e ) {
            System.out.println(e.getMessage());

        }
        System.out.println("New balance: " + account.getBalance());

        System.out.println("Withdrawing 1.0");
        try {
            account.withdraw(1);
        } catch (BankExceptions e ) {
            System.out.println(e.getMessage());

        }
        System.out.println("New balance: " + account.getBalance());

        System.out.println("Another transaction?");
    }
}
