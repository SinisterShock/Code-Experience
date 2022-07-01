package edu.northeaststate.cs1.finalexam.problem2;
/**
 Name:Tyler Burleson
 Email:tburles6@stumail.northeaststate.edu
 */
public class Problem2 {
    public static void main(String[] args) {
        Clock clock = new Clock(0);
        clock.setSeconds(12);
        for (int i = 0; i < 22; i++) {
            System.out.println(clock.getSeconds());
            clock.decrement();
        }
    }
}
