import java.util.Scanner;

public class MethodsPart2 {
    public static void main(String[] args) {
       // Scanner myScanner = new Scanner(System.in);
        //double userChoice;

        //System.out.print("Please enter the number > -58 and < 70: ");
       // userChoice = myScanner.nextDouble();

       // while(userChoice <= -58 || userChoice >= 70){
            //System.out.println("Invalid temperature!");

           // System.out.print("Please enter the number between -58 and 70: ");
           // userChoice = myScanner.nextDouble();
        //}
       // System.out.println("Valid Temperature = " + userChoice);


        //do{
           //System.out.print("Please enter a number between -58 and 70: ");
            //userChoice = myScanner.nextDouble();
            //if (userChoice <=-58 || userChoice >= 70){
               // System.out.println("invalid input");
           // }
        //}while (userChoice <=-58 || userChoice >=70);

        //System.out.println("Valid input: " +userChoice);
        //boolean result = isDivisible(5,2);
       // System.out.println(result);

        int divisor = 3;

        for (int i = 1; i < 101; i++) {
            //System.out.println(i + " is divisible by 2 " + isDivisible(i,divisor));
            if(isDivisible(i,divisor)){
                System.out.println(i + " is evenly divisible by " + divisor);
            }else{
                System.out.println(i + " is not evenly divisible by " + divisor);
            }
        }

    }

    public static int getMin(int x, int y){
        int temp;
        if(x < y){
            temp = x;
        }else{
            temp = y;
        }
        return temp;
    }

    public static boolean isDivisible(int dividend, int divisor){
        boolean check = dividend % divisor == 0;

        return check;
    }
}
