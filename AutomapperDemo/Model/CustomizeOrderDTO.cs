using AutomapperDemo.Model;

namespace AutomapperDemo.Models
{
    public class CustomizeOrderDTO
    {
        //This method will return the Customize Order date
        public static string CustomizeOrderDate(DateTime orderDate)
        {
            //Custom Date Format
            return orderDate.ToString("dd-MM-yyyy");
        }

        //This method will set the TotalPrice directly in the destination object
        public static void CalculateTotalPrice(Order source, OrderDTO destination)
        {
            //Setting the Total Price
            destination.TotalPrice = source.Items.Sum(item => item.Price * item.Quantity);
        }
    }
}
