using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum BookingStatus1
    {
        Default, Initiated, Booked, Cancelled
    }
    public class BookingDetails
    {
        public static int s_bookingID = 100;
        public string BookingID { get; }
        public string UserID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfBooking { get; set; }
        public BookingStatus1 BookingStatus1 { get; set; }

        public BookingDetails(string userID, double totalPrice, DateTime dateOfBooking, BookingStatus1 bookingStatus1)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;
            UserID = userID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            BookingStatus1 = bookingStatus1;
        }

        public BookingDetails(string book1)
        {
            string[] values=book1.Split(",");
            s_bookingID=int.Parse(values[0].Remove(0,3));;
            BookingID = values[0];
            UserID = values[1];
            TotalPrice = double.Parse(values[2]);
            DateOfBooking = DateTime.ParseExact(values[3],"dd/MM/yyyy hh:mm:ss tt",null);
            BookingStatus1 = Enum.Parse<BookingStatus1>(values[4]);
        }
    }
}