package edu.northeaststate.cs2.tests.PersonTest;

public class Scratch01 {
    public static void main(String[] args) {
        int x = 42;
        int y = 37;
        int z = addTwo(x,y);
        System.out.println(z);

        Person person = new Person("Tyler", 19);
        Person person2 = new Person("Olivia", 20);
        System.out.println(person2.getAge());
    }

    public static int addTwo(int intOne, int intTwo){
        return intOne + intTwo;
    }
}
