package edu.northeaststate.cs1.finalexam.problem1;
/**
    Name:Tyler Burleson
    Email:tburles6@stumail.northeaststate.edu
 */
public class Component {
    private String componentNumber;
    private String serialNumber;
    private double mass;
    private double volume;

    public Component(String componentNumber, String serialNumber, double mass, double volume){
        this.componentNumber = componentNumber;
        this.serialNumber = serialNumber;
        this.mass = mass;
        this.volume = volume;
    }
    public String getComponentNumber(){return this.componentNumber;}
    public void setComponentNumber(String componentNumber){this.componentNumber = componentNumber;}

    public String getSerialNumber(){return this.serialNumber;}
    public void setSerialNumber(String serialNumber){this.serialNumber = serialNumber;}

    public double getMass() {return this.mass;}
    public void setMass(double mass) {this.mass = mass;}

    public double getVolume() {return volume;}
    public void setVolume(double volume) {this.volume = volume;}
}
