package edu.northeaststate.cs2.finalexam.problem4;
/**
 * -------------------------------------------
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */
import java.util.ArrayList;

public class Assembly {
    private String name;
    private ArrayList<Part> parts;

    public Assembly(String name) {
        this.name = name;
        parts = new ArrayList<>();
    }

    public String getName() {
        return name;
    }

    public void addPart(Part part){
        this.parts.add(part);
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("Assembly{");
        sb.append("name='").append(name).append('\'');
        for (Part part : this.parts){
            sb.append("\n"+part.toString());
        }
        sb.append('}');
        return sb.toString();
    }
}
