package edu.northeaststate.cs1.projects.projects3;
/**
 * ---------------------------------
 * File Name: Project3.java
 * Project Name: Project3
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */
import java.util.Scanner;
/**
 * Class Name: Project3
 * Purpose: Stores Pseudo-random dice rolls in an array and using methods finds the average, sum, max, min, and median. Using methods it also sorts and lets the user use a linear search and binary search on the array.
 */
public class Project3 {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *
     * @param args not used in this program
     */
    public static void main(String[] args) {
        printWelcomeMessage();
        int loopBreaker = 0;
        while(loopBreaker < 1) {
            int numberOfDice = promptForInteger("Enter the number of dice to roll (o to exit) ");
            if (numberOfDice == 0){
                loopBreaker++ ;
            }else if(numberOfDice >= 1) {
                int numSides = promptForInteger("Enter the number of sides on your dice: ");
                int[] diceArray = new int[numberOfDice];
                randomizeArray(diceArray, numSides);
                System.out.print("Rolling " + numberOfDice + "d" + numSides);
                printArray(diceArray);
                System.out.println();
                System.out.print("Sorting Array:");
                bubbleSort(diceArray);
                printArray(diceArray);
                System.out.println();
                System.out.println("Sum: "+ findSum(diceArray));
                System.out.println("Maximum: "+ findMax(diceArray));
                System.out.println("Minimum: " + findMin(diceArray));
                System.out.println("Average: " + findAverage(diceArray));
                System.out.println("Median: "+ findMedian(diceArray));
                int key = promptForInteger("Enter an integer to search for: ");
                if(linearSearch(diceArray, key) == -1){
                    System.out.println("Linear search: " + key + " not found");
                }else{
                    System.out.println("Linear search: " + key + " found at index " + linearSearch(diceArray, key));
                }

                if(binarySearch(diceArray, key) == -1){
                    System.out.println("Binary search: " + key + " not found");
                }else{
                    System.out.println("Binary search: " + key + " found at index " + binarySearch(diceArray, key));
                }
            }
        }



    }
    /**
     * Method Name: printWelcomeMessage
     * Method Description: Prints a welcome message
     *
     * @param args not used in this program
     */
    public static void printWelcomeMessage(){
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐   Project3-Super Dice Roller 2     ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");
    }
    /**
     * Method Name: promptForInteger
     * Method Description: Generic method used to ask for an integer from the user
     *
     * @param String
     * @param prompt
     */
    public static int promptForInteger(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return myScanner.nextInt();
    }

    /**
     * Method Name: randomizeArray
     * Method Description: Stores Pseudo random numbers in a designated array
     *
     * @param intArray
     * @param numSides
     */
    public static void randomizeArray(int[] intArray, int numSides){
        for (int i = 0; i < intArray.length; i++) {
            int range = (numSides - 1) + 1;
            int result = (int) (Math.random() * range) + 0;
            intArray[i] = result;
        }

    }

    /**
     * Method Name: printArray
     * Method Description: Prints the array to the console
     *
     * @param intArray
     */
    public static void printArray(int[] intArray){
        for (int i = 0; i < intArray.length; i++) {
            System.out.print(" " + intArray[i]);
        }
    }

    /**
     * Method Name: linearSearch
     * Method Description: Uses a linear search to go through the designated array and finds what search term the user has entered
     *
     * @param intArray
     * @param key
     */
    public static int linearSearch(int[] intArray, int key){
        bubbleSort(intArray);
        int foundIndex = -1;
        for (int i = 0; i < intArray.length; i++) {
            if(intArray[i] == key){
                foundIndex = i;
                break;
            }
        }
        return foundIndex;
    }

    /**
     * Method Name: binarySearch
     * Method Description: Uses a binary search to go through the designated array and finds what search term the user has entered
     *
     * @param intArray
     * @param key
     */
    public static int binarySearch(int[] intArray, int key){
        bubbleSort(intArray);
        int low = 0;
        int high = intArray.length - 1;
        int mid = 0;

        while(high >= low){
            mid = (low +high)/ 2;

            if(intArray[mid] == key){
                return mid;
            }else if (key < intArray[mid]){
                high = mid -1;
            }else{
                low = mid +1;
            }

        }return -1;

    }

    /**
     * Method Name: bubbleSort
     * Method Description: Sorts a designated array using an optimized bubble sort
     *
     * @param intArray
     */
    public static void bubbleSort(int[] intArray){
        boolean isSorted;
        for (int i = 0; i < intArray.length; i++) {
            isSorted = true;
            for (int j = 1; j < intArray.length - i ; j++) {
                if (intArray[j] < intArray[j - 1]) {
                    swap(intArray, j - 0, j - 1);
                    isSorted = false;
                }
            }
            if(isSorted){
                break;
            }
        }

    }

    /**
     * Method Name: findSum
     * Method Description: Adds all the entries in a designated array and returns the sum
     *
     * @param intArray
     */
    public static int findSum(int[] intArray){
        int arraySum = 0;
        for (int i = 0; i < intArray.length; i++) {
            arraySum += intArray[i];
        }
        return arraySum;
    }

    /**
     * Method Name: findMax
     * Method Description: Finds the maximum entry in a designated array
     *
     * @param intArray
     */
    public static int findMax(int[] intArray){
        bubbleSort(intArray);
        int arrayMax = intArray[intArray.length - 1];
        return arrayMax;
    }

    /**
     * Method Name: findMin
     * Method Description: Finds the minimum entry in a designated array
     *
     * @param intArray
     */
    public static int findMin(int[] intArray){
        bubbleSort(intArray);
        int arrayMin = intArray[0];
        return arrayMin;
    }

    /**
     * Method Name: findAverage
     * Method Description: Finds the average of all entries in a designated array
     *
     * @param intArray
     */
    public static double findAverage(int[] intArray){
        double arrayAverage = 0;
        arrayAverage = (findSum(intArray)) / intArray.length;
        return arrayAverage;
    }

    /**
     * Method Name: findMedian
     * Method Description: Finds the median in a designated array
     *
     * @param intArray
     */
    public static double findMedian(int[] intArray){
        bubbleSort(intArray);
        double arrayMedian;
        int arrayIndexEven = 0;
        int arrayIndexOdd = 0;
        double arrayIndexOddDouble = 0;
        if(intArray.length % 2 == 0){
            arrayIndexEven = intArray.length / 2;
            arrayMedian = (intArray[arrayIndexEven] + intArray[arrayIndexEven + 1]) / 2;
        }else{
           arrayIndexOddDouble = Math.ceil(intArray.length / 2);
           arrayIndexOddDouble = arrayIndexOdd;
            arrayMedian = intArray[arrayIndexOdd];
        }
        return arrayMedian;
    }

    /**
     * Method Name: swap
     * Method Description: swaps the entries of two indexes in a designated array
     *
     * @param array
     * @param index1
     * @param index2
     */
    public static void swap(int[] array, int index1, int index2){
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
