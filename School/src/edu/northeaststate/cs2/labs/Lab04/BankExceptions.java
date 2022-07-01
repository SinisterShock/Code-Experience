package edu.northeaststate.cs2.labs.Lab04;

/**
 * Class Name: InsufficientFundsException
 * Purpose: Custom extended Exception class to be thrown when insufficient funds are available for withdraw
 */
public class BankExceptions extends Exception{
    /**
     * Method Name: InsufficientFundsException
     * Method Description: Default constructor, calls super class constructor and passes in an Exception message
     */
    public BankExceptions() {
        super();
    }
    public BankExceptions(String message){
        super(message);
    }
}