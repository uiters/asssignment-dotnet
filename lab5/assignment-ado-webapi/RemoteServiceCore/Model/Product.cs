using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteServiceCore.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }

    }

    public static class ProductData
    {
        public static List<Product> ProductList = new List<Product>()
        {
            new Product{ProductID =1, ProductName = "CaPhe",Quantity= 10, UnitPrice=20},
            new Product{ProductID=2, ProductName = "Coca", Quantity=20,UnitPrice=30 }
        };
    }
}
