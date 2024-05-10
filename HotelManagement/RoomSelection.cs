using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum BookingStatus{
        Default, Initiated, Booked, Cancelled
    }
    public class RoomSelection
    {
        public static int s_selectionID=1000;
        public string SelectionID{get; }
        public string RoomID{get; set;}
        public string BookingID{get; set;}
        public DateTime StayingDateFrom{get; set;}
        public DateTime	StayingDateTo{get; set;}
        public double Price{get; set;}
        public double NumberOfDays{get; set;}
        public BookingStatus BookingStatus{get; set;}

        public RoomSelection(string roomID,string bookingID,DateTime dateFrom,DateTime dateTo,double price,double numberOfDays,BookingStatus bookingStatus)
        {
            s_selectionID++;
            SelectionID="SID"+s_selectionID;
            RoomID=roomID;
            BookingID=bookingID;
            StayingDateFrom=dateFrom;
            StayingDateTo=dateTo;
            Price=price;
            NumberOfDays=numberOfDays;
            BookingStatus=bookingStatus;
        }

        public RoomSelection(string selection)
        {
            string[] values=selection.Split(",");
            s_selectionID=int.Parse(values[0].Remove(0,3));
            SelectionID=values[0];
            RoomID=values[1];
            BookingID=values[2];
            StayingDateFrom=DateTime.ParseExact(values[3],"dd/MM/yyyy hh:mm:ss tt",null);
            StayingDateTo=DateTime.ParseExact(values[4],"dd/MM/yyyy hh:mm:ss tt",null);
            Price=double.Parse(values[5]);
            NumberOfDays=double.Parse(values[6]);
            BookingStatus=Enum.Parse<BookingStatus>(values[7]);
        }
    }
}