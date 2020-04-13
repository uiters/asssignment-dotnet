using System;
using System.Data;

namespace ProductLibrary
{
    public class Product
    {
        private int productID;
        private string productName;
        private decimal quantity;
        private int unitPrice;

        public Product(int productID, string productName, int quantity, int unitPrice)
        {
            this.productID = productID;
            this.productName = productName;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }

        public Product(DataRow row)
        {
            productID = Convert.ToInt32(row["ProductID"]);
            productName = Convert.ToString(row["ProductName"]);
            quantity = Convert.ToDecimal(row["Quantity"]);
            unitPrice = Convert.ToInt32(row["UnitPrice"]);
        }


        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public decimal Quantity { get => quantity; set => quantity = value; }
        public int UnitPrice { get => unitPrice; set => unitPrice = value; }

        public decimal SubToal { get => unitPrice * quantity; }
    }
}
