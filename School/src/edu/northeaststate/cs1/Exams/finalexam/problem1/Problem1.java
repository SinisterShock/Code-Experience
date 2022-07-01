package edu.northeaststate.cs1.finalexam.problem1;
/**
 Name:Tyler Burleson
 Email:tburles6@stumail.northeaststate.edu
 */
public class Problem1 {
    public static void main(String[] args) {
        Component component1 = new Component("ae1232", "166254", 12.5, 12.4);

        System.out.println("The component number is: "+  component1.getComponentNumber());
        System.out.println("The Serial number is:" + component1.getSerialNumber());
        System.out.println("The mass is:" + component1.getMass());
        System.out.println("The Volume is:" + component1.getVolume());


        component1.setVolume(8.9);
        component1.setComponentNumber("ar1324");
        component1.setMass(6.5);
        component1.setSerialNumber("66542");

        System.out.println("Here is the new set of information:");
        System.out.println("The component number is: "+  component1.getComponentNumber());
        System.out.println("The Serial number is:" + component1.getSerialNumber());
        System.out.println("The mass is:" + component1.getMass());
        System.out.println("The Volume is:" + component1.getVolume());
    }
}
