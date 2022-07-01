package edu.northeaststate.cs2.tests.files;

import edu.northeaststate.cs2.tests.dice.Dice;

import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;

public class FileWriterDriver {
    public static void main(String[] args) {
        try{

            FileWriter myWriter = new FileWriter("src/edu/northeaststate/cs2/tests/files/test.txt");
            for (int i = 0; i < 100; i++) {
                Dice dice = new Dice(20);
                if (i < 99){
                    myWriter.write(dice.roll() + ",");
                }else{
                    String myString =Integer.toString(dice.roll());
                    myWriter.write(myString);
                }

            }

            myWriter.close();
            System.out.println("Successfully wrote to the file");
        }catch(IOException e){
            System.out.println("An error occured");
            e.printStackTrace();
        }
    }
}
