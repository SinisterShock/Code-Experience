package edu.northeaststate.cs2.labs.Lab04;
/**
 * Class Name: BankAccount
 * Purpose: Set up methods in response to user's input and determine if they are eligible for a deposit or withdraw
 */
public class BankAccount {
    private double balance; //remember in practice to never use float or double data type for money

    /**
     * Method Name: BankAccount
     * Method Description: Default constructor, sets balance to 0.0
     */
    public BankAccount() {
        this.balance = 0.0;
    }

    /**
     * Method Name: deposit
     * Method Description: Adds specified amount to balances
     * @param amount
     */
    public void deposit(double amount) throws BankExceptions{
        if (amount <= 0.0){
            throw new BankExceptions("\t Invalid transaction amount!");
        }else{
            this.balance += amount;
        }

    }

    /**
     * Method Name: withdraw
     * Method Description: Subtracts specified amount from balance if there are sufficient funds, otherwise throws
     * an InsufficientFundsException
     * @param amount
     * @throws BankExceptions
     */
    public void withdraw(double amount) throws BankExceptions {
        if(Double.compare(this.balance, amount) < 0){
            throw new BankExceptions("\t Insufficient funds for transaction requested!");
        }else if(amount <= 0){
            throw  new BankExceptions("\t Invalid transaction amount!");
        }
        else{
            this.balance -= amount;
        }
    }

    /**
     * Method Name: getBalance
     * Method Description: Returns the BankAccount balance attributes
     * @return
     */
    public double getBalance(){
        return this.balance;
    }
}
