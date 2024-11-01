namespace AutomapperDemo.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
}
