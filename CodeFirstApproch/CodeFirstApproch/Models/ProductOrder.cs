namespace CodeFirstApproch.Models
{
    public class ProductOrder
    {
        public int id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int orderId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }    
    }
}