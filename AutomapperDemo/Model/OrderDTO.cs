namespace AutomapperDemo.Model
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; } // Example of a custom format need
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    }
}
