using System;
using System.Collections.Generic;
using System.Text;

class Address
{
    private string StreetAddress { get; set; }
    private string City { get; set; }
    private string StateProvince { get; set; }
    private string Country { get; set; }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{StreetAddress}, {City}, {StateProvince}, {Country}";
    }
}

class Customer
{
    public string Name { get; set; }
    public Address CustomerAddress { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        CustomerAddress = address;
    }

    public bool IsInUSA()
    {
        return CustomerAddress.IsInUSA();
    }
}

class Product
{
    private string Name { get; set; }
    private int ProductId { get; set; }
    private decimal PricePerUnit { get; set; }
    private int Quantity { get; set; }

    public Product(string name, int productId, decimal pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return PricePerUnit * Quantity;
    }
}

class Order
{
    private List<Product> Products { get; set; }
    private Customer Customer { get; set; }

    public Order(Customer customer, List<Product> products)
    {
        Customer = customer;
        Products = products;
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalCost = 0;
        foreach (var product in Products)
        {
            totalCost += product.GetTotalCost();
        }

        // Add shipping cost based on customer location
        totalCost += Customer.IsInUSA() ? 5 : 35;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder("Packing Label:\n");
        foreach (var product in Products)
        {
            packingLabel.AppendLine($"{product.Name} (ID: {product.ProductId})");
        }

        return packingLabel.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nCustomer: {Customer.Name}\nAddress: {Customer.CustomerAddress.GetFullAddress()}";
    }
}

class Program
{
    static void Main()
    {
        // Creating addresses
        Address usaAddress = new Address("123 Main St", "Anytown", "CA", "USA");
        Address nonUsaAddress = new Address("456 Maple St", "Another City", "ProvinceA", "Canada");

        // Creating customers
        Customer usaCustomer = new Customer("John Doe", usaAddress);
        Customer nonUsaCustomer = new Customer("Jane Smith", nonUsaAddress);

        // Creating products
        Product product1 = new Product("Laptop", 101, 800, 2);
        Product product2 = new Product("Smartphone", 202, 400, 3);
        Product product3 = new Product("Headphones", 303, 100, 5);

        // Creating orders
        Order order1 = new Order(usaCustomer, new List<Product> { product1, product2 });
        Order order2 = new Order(nonUsaCustomer, new List<Product> { product2, product3 });

        // Displaying results
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Order Details:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice()}\n");
    }
}
