using System.Reflection;

public class Order
{
    private List<Product> _products = new List<Product>(){};
    private Customer _customer;

    public void CreateCustomer(string[] parsedList)
    {
        string name = parsedList[0];
        string street = parsedList[1];
        string city = parsedList[2];
        string state = parsedList[3];
        string country = parsedList[4];
        _customer = new Customer(name, street, city, state, country);
    }

    public void AddProduct(string[] parsedList)
    {
        string name = parsedList[0];
        int productID = int.Parse(parsedList[1]);
        int pricePerUnit = int.Parse(parsedList[2]);
        int quantity = int.Parse(parsedList[3]);
        _products.Add(new Product(name, productID, pricePerUnit, quantity));
    }
    public int CalculateTotalCost()
    {
        int totalCosts = 0;

        foreach (Product p in _products)
            totalCosts += p.TotalCost();

        if (!_customer.LivesInUS())
            totalCosts += 35;
        else
            totalCosts += 5;

        return totalCosts;
    }
    public string PackingLabel()
    {
        string finalString = "Packing Label: \n";

        foreach (Product p in _products)
            finalString += $" Product Name: {p.GetName()} ID: {p.GetProductID()}\n";
        
        return finalString;
    }
    public string ShippingLabel()
    {
        string finalString = "Shipping Label: \n";

        finalString += $"To: {_customer.GetCustomerName()} \n";
        finalString += $"Full Address: \n {_customer.GetFullAddress()}\n";

        return finalString;
    }
}