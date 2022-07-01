package edu.northeaststate.cs1.finalexam.problem2;
/**
 Name:Tyler Burleson
 Email:tburles6@stumail.northeaststate.edu
 */
public class Clock {
    private int seconds;

    public Clock(int seconds){
        this.seconds = seconds;
    }

    public int getSeconds() {return this.seconds;}

    public void setSeconds(int seconds) {this.seconds = seconds;}

    public int decrement(){
        this.seconds--;
        if(this.seconds == 0){
            this.seconds = 59;
        }
    return this.seconds;
    }
}
