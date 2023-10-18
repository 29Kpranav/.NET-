namespace CodeFirstApproch.Models
{
    public class Order
    {

        public int Id { get; set; }
        public DateTime orderPlaced { get; set; }

        public DateTime? orderFulfilled { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

    }
}