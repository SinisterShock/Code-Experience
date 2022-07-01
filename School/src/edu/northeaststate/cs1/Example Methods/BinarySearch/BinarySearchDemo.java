public class BinarySearchDemo {
    public static void main(String[] args) {
        int[] myArray = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
        int searchTerm = 16;
        int arrayLocation = binarySearch(myArray, searchTerm);
        if(arrayLocation > -1) {
            System.out.println("Array location: " + arrayLocation);
        }else{
            System.out.println("Not found in array");
        }
    }
    public static int binarySearch(int[] array, int searchTerm){
        int low = 0;
        int high = array.length - 1;
        int mid = 0;

        while(high >= low){
            mid = (low +high)/ 2;

            if(array[mid] == searchTerm){
                return mid;
            }else if (searchTerm < array[mid]){
                high = mid -1;
            }else{
                low = mid +1;
            }

        }return -1;
    }
    public static void sawp(int[] array, int index1, int index2){
        int temp= array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
