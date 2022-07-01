/**
 * ---------------------------------
 * File Name: Methods.java
 * Project Name: Methods
 * ---------------------------------
 * Creator's Name: Tyler Burleson
 * Email: tburles6@stumail.northeaststate.edu
 * Course: CISP 1010 TR
 *----------------------------------
 */

/**
 * Class Name: Methods
 * Purpose: creating methods
 */
public class Methods {
    /**
     * Method Name: main
     * Method Description: Entry point for program
     *@param args not used in this program
     */
    public static void main(String[] args) {
       // printWelcomeMessage();
       // printWelcomeMessage("Ben Way", "CISP 1010", "Methods");
        printWelcomeMessage("Tyler Burleson CISP 1010");
       int result = addTwoIntegers(1,2);
        System.out.print(result);
    }
    /**
     * Method Name: printWelcomeMessage
     * Method Description: Prints starting welcome message for Tyler Burleson
     *@param args not used in this program
     */
    public static void printWelcomeMessage(){
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     Tyler Burleson-CISP 1010       ▐\n" +
                "▐           Methods                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");
    }
    /**
     * Method Name: printWelcomeMessage
     * Method Description: Prints starting welcome message for given parameters
     *@param programmerName
     * @param courseName
     * @param labName
     */
    public static void printWelcomeMessage(String programmerName, String courseName, String labName){
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     " + programmerName + " " + courseName + "       ▐\n" +
                "▐           " + labName + "                  ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");
    }
    /**
     * Method Name: printWelcomeMessage
     * Method Description: Prints starting welcome message for given entered message
     *@param message
     */
    public static void printWelcomeMessage(String message){
        System.out.println("▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐\n" +
                "▐     "+ message +"       ▐\n" +
                "▐                                    ▐\n" +
                "▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐▐");
    }
    /**
     * Method Name: addTwoIntegers
     * Method Description: Prints starting welcome message for given entered message
     *@param num1
     * @param num2
     */
    public static int addTwoIntegers(int num1, int num2){
        return num1 + num2;
    }
}
