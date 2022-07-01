public class Lab11 {
    public static void main(String[] args) {
        System.out.print("Loop 1: ");
        for (int n = 5; n < 95; n+= 5) {
            System.out.print(n + " ");
        }
        System.out.println();
        System.out.print("Loop 2: ");
        for (int j = 60; j > 18; j-=2) {
            System.out.print(j + " ");
        }
        System.out.println();
        System.out.print("Loop 3: ");
        for (int f = 0; f < 100; f+=2) {
            if (f % 2 == 0 && f % 3 == 0 && f != 0){
                System.out.print(f + " ");
            }
        }
    }
}
