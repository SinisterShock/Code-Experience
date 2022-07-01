import java.util.Scanner;

public class Lab12 {
    public static void main(String[] args) {
        int intVal = promptForInt("Enter an integer: ");
        double doubleVal = promptForDouble("Enter an double: ");
        short shortVal = promptForShort("Enter a short: ");
        long longVal = promptForLong("Enter a long: ");
        float floatVal = promptForFloat("Enter a float: ");
        String charVal = promptForChar("Enter a Char: ");
        String stringVal = promptForString("Enter a string: ");

        System.out.println("intVal = " + intVal);
        System.out.println("doubleVal = " + doubleVal);
        System.out.println("shortVal = " + shortVal);
        System.out.println("longVal = " + longVal);
        System.out.println("floatVal = " + floatVal);
        System.out.println("charVal = " + charVal);
        System.out.println("stringVal = " + stringVal);
    }
    public static int promptForInt(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return myScanner.nextInt();
    }

    public static double promptForDouble(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return  myScanner.nextDouble();
    }

    public static short promptForShort(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return myScanner.nextShort();
    }

    public static long promptForLong(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return myScanner.nextLong();
    }

    public static float promptForFloat(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return myScanner.nextFloat();
    }

    public static String promptForChar(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return myScanner.next();
    }

    public static String promptForString(String prompt){
        Scanner myScanner = new Scanner(System.in);
        System.out.print(prompt);

        return myScanner.next();
    }
}
