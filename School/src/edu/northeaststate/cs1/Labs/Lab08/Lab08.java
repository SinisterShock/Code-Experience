import java.util.Scanner;

public class Lab08 {
        public static void main(String[] args) {
                Scanner myScanner = new Scanner(System.in);
                int sideNumber;
                double sideNumberDouble;
                double sideLength;
                double area;

                System.out.print("Enter the number of sides: ");
                sideNumber = myScanner.nextInt();
                sideNumberDouble = sideNumber;

                System.out.print("Enter the length of each side: ");
                sideLength = myScanner.nextDouble();

                if(sideNumber >= 3){
                      if(sideLength > 0){
                              area = sideNumber * (Math.pow(sideLength,2))/(4 * Math.tan(Math.PI/sideNumberDouble));
                              System.out.println("The area of the polygon is: "+ area);
                              System.exit(0);
                      }else{
                              System.out.println("Length of sides must be greater than 0");
                              System.exit(0);
                      }
                }else{
                        System.out.println("Number of sides must be at least 3");
                        System.exit(0);
                }
        }
}
