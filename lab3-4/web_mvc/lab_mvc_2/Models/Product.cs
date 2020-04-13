namespace lab_mvc_2.Models {
    public class Product {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float SubTotal { get { return UnitPrice * Quantity; }}
    }
}