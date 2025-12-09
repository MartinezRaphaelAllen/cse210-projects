using System.Transactions;

public class Customer
{
    private string _customerName;
    private Address _address;
    private string _fullAddress;

    public Customer(string name, string street, string city, string state, string country)
    {
        _customerName = name;
        _address = new Address(street, city, state, country);
        _fullAddress = _address.FullAddress();
    }

    public string GetCustomerName()
    {
        return _customerName;
    }

    public string GetFullAddress()
    {
        return _fullAddress;
    }

    public bool LivesInUS()
    {
        bool isIntheUS = _address.USCheck();
        return isIntheUS;
    }
}