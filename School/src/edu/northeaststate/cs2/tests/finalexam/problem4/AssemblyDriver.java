package edu.northeaststate.cs2.finalexam.problem4;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
public class AssemblyDriver {
    public static void main(String[] args) {
        Part part1 = new Part("001", "007112662", 23, 15);
        Part part2 = new Part("002", "222000214", 43, 34);
        Part part3 = new Part("003", "330658111", 12, 20);
        Assembly assembly = new Assembly("Tyler's Shop");

        assembly.addPart(part1);
        assembly.addPart(part2);
        assembly.addPart(part3);

        System.out.println(assembly);
    }
}
