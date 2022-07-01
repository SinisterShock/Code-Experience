package edu.northeaststate.cs2.labs.Lab06.objectoriented;

public class Watt {
    private double volt;
    private double amp;

    public Watt(double volt, double amp) {
        this.volt = volt;
        this.amp = amp;
    }
    public double getValue(){
        return volt * amp;
    }
}
