namespace DataAccess.Models
{
    public class Order
    {
        public string ID { get; set; }
        public string ProductId { get; set; }
        public string Daddress { get; set; }
        public string Baddress { get; set; }
        public string PaymentMethod { get; set; }
        public int Quantity { get; set; }
        
    }
}
