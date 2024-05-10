using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaApplication
{
    public enum OrderStatus
    {
        Default, Initiated, Ordered, Cancelled
    }
    public class OrderDetails
    {
        // •	OrderID (Auto – OID1001)
        // •	UserID
        // •	OrderDate
        // •	TotalPrice
        // •	OrderStatus – (Default, Initiated, Ordered, Cancelled)
        private static int s_orderID = 1000;
        public string OrderId { get; }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string userID, DateTime orderDate, int total, OrderStatus orderStatus)
        {
            s_orderID++;
            OrderId = "OID" + s_orderID;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = total;
            OrderStatus = orderStatus;
        }

         public OrderDetails(string orders)
        {
            string[] values=orders.Split(",");
            s_orderID=int.Parse(values[0].Remove(0,3));
            OrderId = values[0];
            UserID = values[1];
            OrderDate = DateTime.ParseExact(values[2],"dd/MM/yyyy",null);
            TotalPrice = int.Parse(values[3]);
            OrderStatus = Enum.Parse<OrderStatus>(values[4]);
        }
    }
}