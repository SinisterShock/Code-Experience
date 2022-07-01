package edu.northeaststate.cs2.tests.problem2;

import java.util.ArrayList;

public class Business {
    private String name;
    private ArrayList<Customer> customerList;

    public Business(String name) {
        this.name = name;
        customerList = new ArrayList<Customer>();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }


    public void addCustomer(Customer customer){
        customerList.add(customer);
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder("Business{");
        sb.append("name='").append(name).append('\'');
        sb.append(", customerList=");
        for(Customer customer: this.customerList){
            sb.append(customer.toString() + "\n");
        }
        sb.append('}');
        return sb.toString();
    }
}
