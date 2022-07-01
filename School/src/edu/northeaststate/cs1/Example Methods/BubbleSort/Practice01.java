public class Practice01 {
    public static void main(String[] args) {
         //Bubblesort demo
        int[] myArray = {1,2,3,4};
        optimizedBubbleSort(myArray);

        for (int i = 0; i < myArray.length; i++) {
            System.out.print(myArray[i] + " ");
        }

    }

    public static void bubbleSort(int[] array){
        for (int i = 0; i < array.length; i++) {
            for (int j = 1; j < array.length; j++) {
                if(array [j] < array[j - 1])
                    swap(array, j, j-1);
            }
        }
    }

    public static void optimizedBubbleSort(int[] array){
        boolean isSorted;
        for (int i = 0; i < array.length; i++) {
            isSorted = true;
            for (int j = 1; j < array.length - i ; j++) {
                if (array[j] < array[j - 1]) {
                    swap(array, j - 0, j - 1);
                    isSorted = false;
                }
            }
            if(isSorted){
                break;
            }
        }


    }


    public static void swap(int[] array, int index1, int index2){
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

}
