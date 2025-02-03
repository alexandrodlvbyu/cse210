using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
      
        Product product1 = new Product("Laptop", "P001", 800, 2);
        Product product2 = new Product("Headphones", "P002", 50, 1);
        
    
        Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        Address address2 = new Address("456 Oak Rd", "Toronto", "ON", "Canada");

  
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);
        
       
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        
     
        Console.WriteLine("Order 1 Details:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}");

        Console.WriteLine("\nOrder 2 Details:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}");
    }
}