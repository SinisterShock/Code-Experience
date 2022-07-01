package edu.northeaststate.cs2.projects.project1;

import java.util.ArrayList;
import java.util.Scanner;
/**
 * -------------------------------------------
 * File name: EncounterDriver.java
 * Project name: Project01
 * Created By: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1020 MW
 * -------------------------------------------
 */

/**
 * Class Name: EncounterDriver
 * Purpose:Using the Encounter class- take input from the user to create encounters and monsters in those encounters then print the encounter and calculations
 */
public class EncounterDriver {
    public static void main(String[] args) {
        Scanner myScanner = new Scanner(System.in);
        ArrayList<Encounter> encounterArrayList = new ArrayList<>();
        Monster monster;
        boolean isAnotherEncounter = true;
        boolean isAnotherMonster = true;
        String encounterName = "";
        String monsterName = "";
        int monsterHitPoints = 0;
        int monsterArmorClass = 0;
        int monsterAttackDamage = 0;
        String monsterPrompt = "";

        //While the user has not entered quit for the encounter
        while(isAnotherEncounter){
            System.out.print("Enter an encounter name (quit if done): ");
            encounterName = myScanner.nextLine();

            if(encounterName.equalsIgnoreCase("quit")){
                isAnotherEncounter = false;
                System.out.print("Encounter Report" + "\n" + "--------------------------------------------------" + "\n");
                System.out.println("Number of encounters: " + encounterArrayList.size());
                if(encounterArrayList.size() > 0){
                    for (Encounter encounter : encounterArrayList) {
                        System.out.println("Encounter name: " + encounter.getName());
                        System.out.println("  Total monsters: " + encounter.calculateTotalMonsters());
                        System.out.println("  Total Hit Points: " + encounter.calculateTotalHitPoints());
                        System.out.println("  Average Hit Points: " + encounter.calculateAvgHitPoints());
                        System.out.println("  Average Armor Class: " + encounter.calculateAvgArmorClass());
                        System.out.println("  Average Attack Damage: " + encounter.calculateAvgAttackDamage());
                        System.out.println("  Monsters: ");
                        System.out.print(encounter);
                    }
                }

            }else{
                //create monsters
                Encounter encounter = new Encounter(encounterName);
                encounterArrayList.add(encounter);

                isAnotherMonster = true;
                while(isAnotherMonster){
                    System.out.print("  Enter monster name: ");
                    monsterName = myScanner.nextLine();
                    System.out.print("  Enter monster hit points: ");
                    monsterHitPoints = myScanner.nextInt();
                    System.out.print("  Enter monster armor class: ");
                    monsterArmorClass = myScanner.nextInt();
                    System.out.print("  Enter monster attack damage: ");
                    monsterAttackDamage = myScanner.nextInt();

                    myScanner.nextLine();// flushing out the buffer

                    encounter.addMonster(monsterName, monsterHitPoints, monsterArmorClass, monsterAttackDamage);

                    System.out.print("Would you like to add another monster to " + encounterName + "? (Y or N): ");
                    monsterPrompt = myScanner.nextLine();

                    if(monsterPrompt.equalsIgnoreCase("N")){
                        isAnotherMonster = false;
                    }
                }//end of monster loop
            }//end of creating an encounter
        }//end of encounter loop
    }//end main
}//end project01
