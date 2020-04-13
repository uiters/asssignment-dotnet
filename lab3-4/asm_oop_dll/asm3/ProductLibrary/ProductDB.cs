using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;


namespace ProductLibrary
{
    public interface IProductDB
    {
        bool AddNewProduct(Product product);
        bool RemoveProduct(Product product);
        bool UpdateProduct(Product product);
        Product FindProduct(int productId);
        List<Product> GetProductList();
    }

    public class ProductDB : IProductDB
    {
        private DataProvider provider;

        private readonly string createQuery = "Insert into Products (ProductID, ProductName, UnitPrice, Quantity) values ( @productId , @productName , @unitPrice , @quantity )";

        private readonly string getListQuery = "select * from Products";

        private readonly string findQuery = "select * from Products where ProductID = @ProductID";

        private readonly string deleteQuery = "delete from Products where ProductID = @ProductID";

        private readonly string updateQuery = "UPDATE Products SET ProductName = @ProductName , UnitPrice = @UnitPrice , Quantity = @Quantity where ProductID = @ProductID";


        public ProductDB(DataProvider provider)
        {
            this.provider = provider;
        }

        public bool AddNewProduct(Product product)
        {
            return provider.ExecuteNoneQuery(createQuery, new object[] { product.ProductID, product.ProductName, product.UnitPrice, product.Quantity }) > 0;
        }

        public Product FindProduct(int productId)
        {
            DataTable table = provider.ExecuteQuery(findQuery, new object[] { productId });
            if (table.Rows.Count > 0)
                return new Product(table.Rows[0]);
            else return null;
        }

        public List<Product> GetProductList()
        {
            DataTable data = provider.ExecuteQuery(getListQuery);
            List<Product> products = new List<Product>();
            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                products.Add(product);
            }
            return products;
        }

        public bool RemoveProduct(Product product)
        {
            return provider.ExecuteNoneQuery(deleteQuery, new object[] { product.ProductID }) > 0;
        }

        public bool UpdateProduct(Product product)
        {
            return provider.ExecuteNoneQuery(updateQuery, new object[] { product.ProductName, product.UnitPrice, product.Quantity, product.ProductID }) > 0;
        }
    }
}