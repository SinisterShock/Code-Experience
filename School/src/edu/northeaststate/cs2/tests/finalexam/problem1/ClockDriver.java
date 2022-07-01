package edu.northeaststate.cs2.finalexam.problem1;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
public class ClockDriver {
    public static void main(String[] args) {
        Clock clock = new Clock(42);

        for (int i = 0; i < 8023; i++) {
            clock.increment();
        }
        System.out.println(clock.getMillis());
    }
}
