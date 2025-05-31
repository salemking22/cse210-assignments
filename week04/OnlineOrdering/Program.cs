using System;

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Elm Street", "New York", "NY", "USA");
        Address address2 = new Address("456 Maple Avenue", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        order1.AddProduct(new Product("Laptop", "A123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "B456", 49.99, 2));

        order2.AddProduct(new Product("Monitor", "C789", 199.99, 1));
        order2.AddProduct(new Product("Keyboard", "D012", 79.99, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");

        Console.WriteLine("\n-------------------\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
    }
}
