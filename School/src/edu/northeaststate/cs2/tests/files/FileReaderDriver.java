package edu.northeaststate.cs2.tests.files;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;
import java.util.StringTokenizer;

public class FileReaderDriver {
    public static void main(String[] args) {
        try{
            int tokens = 0;
            StringTokenizer myTokenizer;
            File myObj = new File("src/edu/northeaststate/cs2/tests/files/test.txt");
            Scanner myReader = new Scanner(myObj);
            while (myReader.hasNextLine()){
                String myData = myReader.nextLine();
                System.out.println(myData);
                myTokenizer = new StringTokenizer(myData, ",");
                tokens = myTokenizer.countTokens();
                int criticals = 0;
                while (myTokenizer.hasMoreTokens()){
                    if (myTokenizer.nextToken().equalsIgnoreCase("20")){
                        System.out.println(myTokenizer.nextToken() + " CRITICAL!!!!");
                        criticals++;
                    }else{
                        System.out.println(myTokenizer.nextToken());
                    }
                }
                System.out.println("Criticals: " + criticals + "\n" + "Tokens: " + tokens);
            }

            myReader.close();
        }catch (FileNotFoundException e){
            System.out.println(e.getMessage());
            e.printStackTrace();
        }
    }
}
