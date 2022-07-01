public class ArrayExample {
    public static void main(String[] args) {
        int[] myArray;

        myArray = new int[1000];

        for (int i = 0; i < myArray.length; i++) {

            myArray[i] = rollDice(1,100);
            if (myArray[i] == 42){
                System.out.println( i + ": " + myArray[i]);
            }

        }


//        System.out.println(myArray[0]);
//        System.out.println(myArray[1]);
//        System.out.println(myArray[2]);
//        System.out.println(myArray[3]);
//        System.out.println(myArray[4]);
//        System.out.println(myArray[5]);


    }
    /**
     * Method Name: rollDice
     * Method Description: Gets a pseudorandom integer that is >=lower bound and < upper bound
     *@param upperBound
     * @param lowerBound
     * @return
     */
    public static int rollDice(int lowerBound, int upperBound) {
        int range = (upperBound - lowerBound) + 1;
        int result = (int) (Math.random() * range) + lowerBound;
        return result;
    }
}
