using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
               
        Random _randomGenerator = new Random();
        List<int> _chosenCustomerList = new List<int>(){};
        List<Order> _orders = new List<Order>() {};
        List<string> _customerInfo = new List<string>()
        {
          "Gabriel Allen Martinez,Blk 7 Lt 2,Antipolo,Rizal,Philippines",
          "Gage Simmons,139 W 4th S,Rexburg,Idaho,USA",
          "Jorge Enriquez,115 Maharlika Rd,Nou Barris,Barcelona,Spain",
          "Will Anderson, 52 E 7th N,Provo,Utah,USA"  
        };
        List<string> _products = new List<string>()
        {
            "Monitor mount,105039,15,10",
            "Gaming PC,202132,1200,1",
            "Phone repair tool set,509412,30,3",
            "World famous cooking book,104525,20,8"
        };
        int chosenCustomerIndex;

        for (int i = 0; i < 3; i++)
        {
            List<int> _chosenProductList = new List<int>(){};
            int chosenProductIndex; 
            Order pendingOrder = new Order();
            int purchasedProducts = _randomGenerator.Next(2,4);

            //creating the customer for new order
            do
            {
                chosenCustomerIndex = _randomGenerator.Next(0,4);
            } while (_chosenCustomerList.Contains(chosenCustomerIndex));
            _chosenCustomerList.Add(chosenCustomerIndex);
            string[] parsedCustomer = _customerInfo[chosenCustomerIndex].Split(",");
            pendingOrder.CreateCustomer(parsedCustomer);

            //creating products
            for (int l = 0; l < purchasedProducts; l++)
            {
                do
                {
                    chosenProductIndex = _randomGenerator.Next(0,4);
                } while (_chosenProductList.Contains(chosenProductIndex));
                _chosenProductList.Add(chosenProductIndex);
                string[] parsedProduct = _products[chosenProductIndex].Split(",");
                pendingOrder.AddProduct(parsedProduct);
            }
            _orders.Add(pendingOrder);
        }

        //printing the finalized orders
        foreach (Order o in _orders)
        {
            Console.Write(o.ShippingLabel());
            Console.Write(o.PackingLabel());
            Console.WriteLine($"Total Cost of Order: ${o.CalculateTotalCost()}");
            Console.WriteLine();
        }
    }
}