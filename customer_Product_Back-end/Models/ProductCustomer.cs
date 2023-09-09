namespace customer_Product_Back_end.Models
{
    public class ProductCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string SaleDate { get; set; }
    }
}
