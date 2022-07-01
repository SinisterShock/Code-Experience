package edu.northeaststate.cs2.finalexam.problem4;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
public class Part {
    private String partNumber;
    private String serialNumber;
    private int weight;
    private double surfaceArea;

    public Part(String partNumber, String serialNumber, int weight, double surfaceArea) {
        this.partNumber = partNumber;
        this.serialNumber = serialNumber;
        this.weight = weight;
        this.surfaceArea = surfaceArea;
    }

    public String getPartNumber() {
        return partNumber;
    }

    public void setPartNumber(String partNumber) {
        this.partNumber = partNumber;
    }

    public String getSerialNumber() {
        return serialNumber;
    }

    public void setSerialNumber(String serialNumber) {
        this.serialNumber = serialNumber;
    }

    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    public double getSurfaceArea() {
        return surfaceArea;
    }

    public void setSurfaceArea(double surfaceArea) {
        this.surfaceArea = surfaceArea;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("Part{");
        sb.append("partNumber='").append(partNumber).append('\'');
        sb.append(", serialNumber='").append(serialNumber).append('\'');
        sb.append(", weight=").append(weight);
        sb.append(", surfaceArea=").append(surfaceArea);
        sb.append('}');
        return sb.toString();
    }
}
