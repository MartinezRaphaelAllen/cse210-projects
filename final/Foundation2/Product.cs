public class Product
{
    private string _name;
    private int _productID;
    private int _pricePerUnit;
    private int _quantity;

    public Product(string name, int productID, int pricePerUnit, int quantity)
    {
        _name = name;
        _productID = productID;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }
    public string GetName()
    {
        return _name;
    }
    public int GetProductID()
    {
        return _productID;
    }
    public int TotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}