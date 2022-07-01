package edu.northeaststate.cs2.finalexam.problem1;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
public class Clock {
    private int millis;

    public Clock(int millis) {
        this.millis = millis;
    }
    public void increment(){
        if (millis < 999){
            millis++;
        }else{
            millis = 0;
        }
    }

    public int getMillis() {
        return millis;
    }
}
