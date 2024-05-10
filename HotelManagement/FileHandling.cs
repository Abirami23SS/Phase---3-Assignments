using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("HotelManagement"))
            {
                System.Console.WriteLine("Creating folder");
                Directory.CreateDirectory("HotelManagement");
            }
            if (!File.Exists("HotelManagement/UserRegistration.csv"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/UserRegistration.csv").Close();
            }
            if (!File.Exists("HotelManagement/BookingDetails.csv"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/BookingDetails.csv").Close();
            }
            if (!File.Exists("HotelManagement/RoomDetails.csv"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/RoomDetails.csv").Close();
            }
            if (!File.Exists("HotelManagement/RoomSelection.csv"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/RoomSelection.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string[] user = new string[Operation.userList.Count];
            for (int i = 0; i < Operation.userList.Count; i++)
            {
                user[i] = Operation.userList[i].UserID + "," + Operation.userList[i].UserName + "," + Operation.userList[i].MobileNumber + "," + Operation.userList[i].AadharNumber + "," + Operation.userList[i].Address + "," + Operation.userList[i].FoodType + "," + Operation.userList[i].Gender + "," + Operation.userList[i]._balance;
            }
            File.WriteAllLines("HotelManagement/UserRegistration.csv", user);
            string[] book = new string[Operation.bookingList.Count];
            for (int i = 0; i < Operation.bookingList.Count; i++)
            {
                book[i] = Operation.bookingList[i].BookingID + "," + Operation.bookingList[i].UserID + "," + Operation.bookingList[i].TotalPrice + "," + Operation.bookingList[i].DateOfBooking + "," + Operation.bookingList[i].BookingStatus1;
            }
            File.WriteAllLines("HotelManagement/BookingDetails.csv", book);
            string[] room = new string[Operation.roomList.Count];
            for (int i = 0; i < Operation.roomList.Count; i++)
            {
                room[i] = Operation.roomList[i].RoomID + "," + Operation.roomList[i].RoomType + "," + Operation.roomList[i].NumberOfBeds + "," + Operation.roomList[i].PricePerDay;
            }
            File.WriteAllLines("HotelManagement/RoomDetails.csv", room);

            string[] roomSelection = new string[Operation.roomSelectionList.Count];
            for (int i = 0; i < Operation.roomSelectionList.Count; i++)
            {
                roomSelection[i] = Operation.roomSelectionList[i].SelectionID + "," + Operation.roomSelectionList[i].RoomID + "," + Operation.roomSelectionList[i].BookingID + "," + Operation.roomSelectionList[i].StayingDateFrom + "," + Operation.roomSelectionList[i].StayingDateTo + "," + Operation.roomSelectionList[i].Price + "," + Operation.roomSelectionList[i].NumberOfDays;
            }
            File.WriteAllLines("HotelManagement/RoomSelection.csv", roomSelection);
        }

        public static void ReadToCSV()
        {
            string[] user = File.ReadAllLines("HotelManagement/UserRegistration.csv");
            foreach (string users in user)
            {
                UserRegistration newUser = new UserRegistration(users);
                Operation.userList.Add(newUser);
            }
            
            string[] room = File.ReadAllLines("HotelManagement/RoomDetails.csv");
            foreach (string rooms in room)
            {
                RoomDetails newRoom = new RoomDetails(rooms);
                Operation.roomList.Add(newRoom);
            }
            string[] book = File.ReadAllLines("HotelManagement/BookingDetails.csv");
            foreach (string book1 in book)
            {
                BookingDetails newBooking = new BookingDetails(book1);
                Operation.bookingList.Add(newBooking);
            }
            string[] roomSelection = File.ReadAllLines("HotelManagement/RoomSelection.csv");
            foreach (string selection in roomSelection)
            {
                RoomSelection room1 = new RoomSelection(selection);
                Operation.roomSelectionList.Add(room1);
            }
        }
    }
}