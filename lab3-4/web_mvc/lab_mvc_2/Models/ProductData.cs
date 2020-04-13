using System.Collections.Generic;
using System.Linq;

namespace lab_mvc_2.Models {
    public class ProductData {
        private static List<Product> ProdList = new List<Product> ();

        public static List<Product> ProductList {
            get { return ProdList; }
        }

        public static Product GetProductByID (int productID) {
            return ProductList.FirstOrDefault (c => c.ProductID.Equals (productID));
        }
        public static bool AddProduct (Product newProduct) {
            Product product = ProductList.SingleOrDefault (c => c.ProductID.Equals (newProduct.ProductID));

            if (product == null) {
                ProductList.Add (newProduct);
                return true;
            }

            return false;
        }
        public static bool UpdateProduct (Product editProduct) {
            Product product = ProductList.SingleOrDefault (c => c.ProductID.Equals (editProduct.ProductID));

            if (product != null) {
                product.ProductID = editProduct.ProductID;
                product.ProductName = editProduct.ProductName;
                product.Quantity = editProduct.Quantity;
                product.UnitPrice = editProduct.UnitPrice;
                return true;
            }

            return false;
        }

        public static bool DeleteProduct (int productID) {

            Product product = ProductList.SingleOrDefault(c => c.ProductID == productID);

            if(product != null){
                ProductList.Remove(product);
                return true;
            }
            return false;
        }
    }
}