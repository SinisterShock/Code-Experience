package edu.northeaststate.cs2.tests.problem2;

public class BusinessDriver {
    public static void main(String[] args) {
        Customer customer1 = new Customer("Jason", "Bourne", "9990101223", "JesusChristsIts@gmail.com");
        Customer customer2 = new Customer("Jenny", "Luanne", "5674231899", "jenlane@gmail.com");
        Customer customer3 = new Customer("Bob", "Charles", "4231234567", "BobbyC@gmail.com");
        Business business = new Business("Charley's Pizza");

        business.addCustomer(customer1);
        business.addCustomer(customer2);
        business.addCustomer(customer3);

        System.out.println(business);
    }
}
