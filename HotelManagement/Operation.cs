using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class Operation
    {
        public static CustomList<UserRegistration> userList = new CustomList<UserRegistration>();
        public static CustomList<RoomDetails> roomList = new CustomList<RoomDetails>();
        public static CustomList<RoomSelection> roomSelectionList = new CustomList<RoomSelection>();
        public static CustomList<BookingDetails> bookingList = new CustomList<BookingDetails>();
        public static UserRegistration currentUser;

        public static void AddDefaultData()
        {
            UserRegistration user1 = new UserRegistration("Ravichandran", 23456789, 977425790, "Chennai", FoodType.Veg, Gender.Male, 5000);
            userList.Add(user1);
            UserRegistration user2 = new UserRegistration("Baskaran", 9987230913, 123498098, "Chennai", FoodType.NonVeg, Gender.Male, 6000);
            userList.Add(user2);

            RoomDetails room1 = new RoomDetails(RoomType.Standard, 2, 500);
            roomList.Add(room1);
            RoomDetails room2 = new RoomDetails(RoomType.Standard, 4, 700);
            roomList.Add(room2);
            RoomDetails room3 = new RoomDetails(RoomType.Standard, 2, 500);
            roomList.Add(room3);
            RoomDetails room4 = new RoomDetails(RoomType.Standard, 2, 500);
            roomList.Add(room4);
            RoomDetails room5 = new RoomDetails(RoomType.Delux, 2, 1000);
            roomList.Add(room5);
            RoomDetails room6 = new RoomDetails(RoomType.Delux, 2, 1000);
            roomList.Add(room6);
            RoomDetails room7 = new RoomDetails(RoomType.Delux, 4, 1400);
            roomList.Add(room7);
            RoomDetails room8 = new RoomDetails(RoomType.Suit, 2, 2000);
            roomList.Add(room8);
            RoomDetails room9 = new RoomDetails(RoomType.Suit, 2, 2000);
            roomList.Add(room9);
            RoomDetails room10 = new RoomDetails(RoomType.Suit, 4, 2500);
            roomList.Add(room10);

            RoomSelection roomSelection1 = new RoomSelection("BID101", "RID101", new DateTime(2022, 11, 11, 06, 00, 00, 00), new DateTime(2022, 11, 12, 02, 00, 00, 00), 750, 1.5, BookingStatus.Booked);
            roomSelectionList.Add(roomSelection1);
            RoomSelection roomSelection2 = new RoomSelection("BID101", "RID102", new DateTime(2022, 11, 11, 10, 00, 00, 00), new DateTime(2022, 11, 12, 09, 00, 00, 00), 700, 1, BookingStatus.Booked);
            roomSelectionList.Add(roomSelection2);
            RoomSelection roomSelection3 = new RoomSelection("BID102", "RID103", new DateTime(2022, 11, 12, 09, 00, 00, 00), new DateTime(2022, 11, 12, 09, 00, 00, 00), 500, 1, BookingStatus.Cancelled);
            roomSelectionList.Add(roomSelection3);
            RoomSelection roomSelection4 = new RoomSelection("BID102", "RID103", new DateTime(2022, 11, 12, 06, 00, 00, 00), new DateTime(2022, 11, 12, 12, 30, 00, 00), 1500, 1.5, BookingStatus.Cancelled);
            roomSelectionList.Add(roomSelection4);

            BookingDetails booking1 = new BookingDetails("SF1001", 1450, new DateTime(2022, 11, 10), BookingStatus1.Booked);
            bookingList.Add(booking1);
            BookingDetails booking2 = new BookingDetails("SF1002", 2000, new DateTime(2022, 11, 10), BookingStatus1.Cancelled);
            bookingList.Add(booking2);

            foreach (UserRegistration user in userList)
            {
                System.Console.WriteLine($"  {user.UserID}  |  {user.UserName}  |  {user.MobileNumber}  |  {user.AadharNumber}  |  {user.Address}  |  {user.FoodType}  |  {user.Gender}  |  {user._balance}");
            }
            foreach (RoomDetails room in roomList)
            {
                System.Console.WriteLine($"  {room.RoomID}  |  {room.RoomType}  |  {room.NumberOfBeds}  |  {room.PricePerDay}");
            }
            foreach (RoomSelection roomSelection in roomSelectionList)
            {
                System.Console.WriteLine($"  {roomSelection.SelectionID}  |  {roomSelection.BookingID}  |  {roomSelection.RoomID}  |  {roomSelection.StayingDateFrom.ToString("dd/MM/yyyy hh:mm:ss tt")}  |  {roomSelection.StayingDateTo.ToString("dd/MM/yyyy hh:mm:ss tt")}  |  {roomSelection.Price}  |  {roomSelection.NumberOfDays}  |  {roomSelection.BookingStatus}");
            }
            foreach (BookingDetails booking in bookingList)
            {
                System.Console.WriteLine($"  {booking.BookingID}  |  {booking.UserID}  |  {booking.TotalPrice}  |  {booking.DateOfBooking.ToString("dd/MM/yyyy hh:mm:ss tt")}  |  {booking.BookingStatus1}");
            }
        }

        public static void MainMenu()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("Application for hotel management");
                Console.WriteLine("1.UserRegister  2.UserLogin  3.Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            //System.Console.WriteLine("Register Your Deatils");
                            UserRegister();
                            break;
                        }
                    case 2:
                        {
                            // System.Console.WriteLine("Login Menu");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            //System.Console.WriteLine("Exit");
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }

        public static void UserRegister()
        {
            Console.WriteLine("User Registartion...");
            Console.Write("Enter User name : ");
            string userName = Console.ReadLine();
            Console.Write("Enter Mobile number : ");
            long mobile = long.Parse(Console.ReadLine());
            Console.Write("Enter Aadhar number : ");
            int aadharNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Address : ");
            string address = Console.ReadLine();
            Console.Write("Enter Food type : ");
            FoodType foodType = Enum.Parse<FoodType>(Console.ReadLine());
            Console.Write("Enter Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine());
            Console.Write("Enter WalletBalnce : ");
            double _balance = double.Parse(Console.ReadLine());

            UserRegistration newUser = new UserRegistration(userName, mobile, aadharNumber, address, foodType, gender, _balance);
            userList.Add(newUser);
            System.Console.WriteLine("Registered successfully : " + newUser.UserID);
        }

        public static void UserLogin()
        {

            System.Console.WriteLine("Enter user ID ");
            //•	Ask for the “User ID” of the user. Check the “User ID” in the user list.
            string userID = Console.ReadLine();
            currentUser = BinarySearch.BinarySearchLogin(userID);
            if (currentUser != null)
            {
                System.Console.WriteLine("Logged in succesfully");

                SubMenu();
            }
            else
            {
                System.Console.WriteLine("Invalid user ID");
            }
        }

        public static void SubMenu()
        {
            System.Console.WriteLine("SubMenu");
            int choice;
            bool temp = true;
            do
            {
                System.Console.WriteLine("1.ViewCustomer Profile  2.BookRoom  3.ModifyBooking  4.CancelBooking  5.BookingHistory  6.WalletRecharge  7.Show WalletBalance  8.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            ViewCustomerProfile();
                            break;

                        }
                    case 2:
                        {
                            BookRoom();
                            break;
                        }
                    case 3:
                        {
                            ModifyBooking();
                            break;
                        }
                    case 4:
                        {
                            CancelBooking();
                            break;
                        }
                    case 5:
                        {
                            BookingHistory();
                            break;
                        }
                    case 6:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalnce();
                            break;
                        }
                    case 8:
                        {
                            temp = false;
                            break;
                        }

                }
            } while (temp);
        }

        public static void ViewCustomerProfile()
        {

            foreach (UserRegistration user in userList)
            {
                if (currentUser.UserID == user.UserID)
                {
                    Console.WriteLine($"  {user.UserID}  |  {user.UserName}  |  {user.MobileNumber}  |  {user.AadharNumber}  |  {user.Address}  |  {user.FoodType}  |  {user.Gender}  |  {user._balance}");
                }
            }
        }

        public static void BookRoom()
        {
            //create temp booking object
            CustomList<BookingDetails> tempBooking = new CustomList<BookingDetails>();
            BookingDetails booking = new BookingDetails(currentUser.UserID, 0, DateTime.Now, BookingStatus1.Initiated);
            //create temp room selection
            CustomList<RoomSelection> tempRoom = new CustomList<RoomSelection>();
            //RoomSelection selection = new RoomSelection("0", "0", DateTime.Now, DateTime.Now, 0, 0, BookingStatus.Initiated);
            //show list of avilable rooms by traversing room details
            Console.WriteLine("List of rooms");
            foreach (RoomDetails room in roomList)
            {
                Console.WriteLine($"  {room.RoomID}  |  {room.RoomType}  |  {room.NumberOfBeds}  |  {room.PricePerDay}");
            }
            double price = 0;
            double totalPrice = 0;
            string option = "";
            do
            {
                //ask user datefrom  and dateto room id and no of days
                Console.WriteLine("Enter DateFrom ");
                DateTime dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);
                Console.WriteLine("Enter DateTo ");
                DateTime dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);
                Console.WriteLine("Enter Room ID ");
                string roomID = Console.ReadLine();
                Console.WriteLine("Enter No of Days Of Booking ");
                double days = double.Parse(Console.ReadLine());
                bool flag = true;

                foreach (RoomSelection roomSelection in roomSelectionList)
                {
                    foreach (RoomDetails room in roomList)
                    {
                        flag = false;
                        if (roomID == room.RoomID)
                        {
                            //based on data check booking status is booked or not
                            if (roomSelection.BookingStatus != BookingStatus.Booked && roomID == room.RoomID)
                            {
                                if (room.PricePerDay <= currentUser.WalletBalance)
                                {
                                    price = days * room.PricePerDay;
                                    totalPrice += price;
                                    //not booked means create object and add to temp room selection
                                    RoomSelection temp1 = new RoomSelection(roomID, roomSelection.BookingID, dateFrom, dateTo, price, days, BookingStatus.Booked);
                                    tempRoom.Add(temp1);
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient Balance");
                                }
                            }
                        }
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid ID");
                }
                Console.WriteLine("Ask the user whether he want to book another room");
                option = Console.ReadLine();
            } while (option == "yes");
            Console.WriteLine("Ask the user whether he want to conform the room");
            string option1 = Console.ReadLine();
            bool temp = true;
            if (option1 == "yes")
            {

                do
                {
                    if (totalPrice <= currentUser.WalletBalance)
                    {
                        temp = true;
                        bookingList.AddRange(tempBooking);
                        booking.BookingStatus1 = BookingStatus1.Booked;
                        booking.TotalPrice = totalPrice;
                        currentUser.DeductBalance(totalPrice);
                        bookingList.Add(booking);
                        Console.WriteLine("Booked successfully " + booking.BookingID);
                    }
                    else
                    {
                        System.Console.WriteLine("Insufficient balance do recharge");
                        Console.Write("Are you willing to recharge: yes/no: ");
                        string choice1 = Console.ReadLine().ToLower();
                        if (choice1 == "yes")
                        {
                            temp = false;
                            Console.Write("Enter the amount to be recharged: ");
                            double amount = double.Parse(Console.ReadLine());
                            currentUser.WalletRecharge(amount);
                            Console.WriteLine("Your current balance is " + currentUser.WalletBalance);
                        }
                        else
                        {
                            temp = true;
                            System.Console.WriteLine("Booking not confirmed");
                        }
                    }
                } while (temp);
            }
            else
            {
                Console.WriteLine("Booking not confirmed");
            }

        }

        public static void ModifyBooking()
        {
            bool flag = true;
            foreach (BookingDetails booking in bookingList)
            {
                if (currentUser.UserID == booking.UserID && booking.BookingStatus1 == BookingStatus1.Booked)
                {
                    flag = false;
                    Console.WriteLine($"  {booking.BookingID}  |  {booking.UserID}  |  {booking.TotalPrice}  |  {booking.DateOfBooking}  |  {booking.BookingStatus1}");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No bookiing history found");
            }
            //ask the user
            System.Console.WriteLine("Enter a booking ID ");
            string bookingID = Console.ReadLine();
            foreach (BookingDetails booking1 in bookingList)
            {
                if (booking1.BookingID == bookingID && booking1.BookingStatus1 == BookingStatus1.Booked)
                {
                    foreach (RoomSelection roomSelection in roomSelectionList)
                    {
                        if (roomSelection.BookingID == bookingID && roomSelection.BookingStatus == BookingStatus.Booked)
                        {
                            System.Console.WriteLine($"  {roomSelection.SelectionID}  |  {roomSelection.BookingID}  |  {roomSelection.RoomID}  |  {roomSelection.StayingDateFrom}  |  {roomSelection.StayingDateTo}  |  {roomSelection.Price}  |  {roomSelection.NumberOfDays}  |  {roomSelection.BookingStatus}");
                        }
                    }
                    System.Console.WriteLine("Enter the selection ID");
                    string selectionId = Console.ReadLine();
                    foreach (RoomSelection roomSelection2 in roomSelectionList)
                    {
                        if (roomSelection2.SelectionID == selectionId && currentUser.UserID == booking1.UserID)
                        {
                            System.Console.WriteLine("1.CancelSelected Room  2.AddNew Room");
                            int option = int.Parse(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    {
                                        currentUser.DeductBalance(booking1.TotalPrice);
                                        roomSelection2.BookingStatus = BookingStatus.Cancelled;
                                        System.Console.WriteLine("Selected room cancelled");
                                        break;
                                    }
                                case 2:
                                    {
                                        foreach (RoomDetails room in roomList)
                                        {
                                            System.Console.WriteLine($"  {room.RoomID}  |  {room.RoomType}  |  {room.NumberOfBeds}  |  {room.PricePerDay}");
                                        }
                                        System.Console.WriteLine("Enter room ID ");
                                        string roomID = Console.ReadLine();
                                        //the user to enter room ID and check in and out date and time.
                                        System.Console.WriteLine("Enter check-in ");
                                        DateTime dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);
                                        System.Console.WriteLine("Enter check-out ");
                                        DateTime dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);
                                        //2. Ask the user to enter number of days room is required.
                                        System.Console.WriteLine("Enter no of rooms required");
                                        int rooms = int.Parse(Console.ReadLine());
                                        double total = 0;
                                        foreach (RoomDetails room1 in roomList)
                                        {
                                            if (room1.RoomID == roomID && roomSelection2.BookingStatus == BookingStatus.Cancelled)
                                            {
                                                //4.If the room is available means then calculate amount
                                                total=rooms*room1.PricePerDay;
                                                //5.Check the user has enough balance. If he has means deduct the amount from user.
                                                if (currentUser.WalletBalance >= total)
                                                {
                                                    //6.Add the amount to booking details
                                                    currentUser.DeductBalance(total);
                                                    RoomSelection roomSelection1 = new RoomSelection(roomID,roomSelection2.BookingID, dateFrom, dateTo, total, rooms, BookingStatus.Booked);
                                                    roomSelectionList.Add(roomSelection1);
                                                    System.Console.WriteLine("Booking modified successfully");
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine("Do Recharge");
                                                }
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                    }


                }
            }
        }


        public static void CancelBooking()
        {

            bool flag1 = true;
            //Need to show the current user’s booking history whose booking status is Booked 
            foreach (BookingDetails booking in bookingList)
            {
                if (currentUser.UserID == booking.UserID && booking.BookingStatus1 == BookingStatus1.Booked)
                {
                    flag1 = false;
                    Console.WriteLine($"  {booking.BookingID}  |  {booking.UserID}  |  {booking.TotalPrice}  |  {booking.DateOfBooking}  |  {booking.BookingStatus1}");
                }
            }
            if (flag1)
            {
                System.Console.WriteLine("No booking Found");
            }
            if (!flag1)
            {
                //ask the user to pick booking ID
                System.Console.WriteLine("Pick a bookingID");
                string bookingID = Console.ReadLine();
                bool flag = true;
                foreach (BookingDetails book in bookingList)
                {
                    if (bookingID == book.BookingID && book.BookingStatus1 == BookingStatus1.Booked)
                    {
                        flag = false;
                        currentUser.WalletRecharge(book.TotalPrice);
                        book.BookingStatus1 = BookingStatus1.Cancelled;
                        System.Console.WriteLine("Booking cancelled");
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid Booking Id");
                }

            }

        }

        public static void BookingHistory()
        {
            bool flag = true;
            foreach (BookingDetails booking in bookingList)
            {
                if (currentUser.UserID == booking.UserID)
                {
                    flag = false;
                    Console.WriteLine($"  {booking.BookingID}  |  {booking.UserID}  |  {booking.TotalPrice}  |  {booking.DateOfBooking}  |  {booking.BookingStatus1}");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("No bookiing history found");
            }
            if (!flag)
            {
                System.Console.WriteLine("Enter a booking ID ");
                string bookingID = Console.ReadLine();
                bool flag1 = false;
                foreach (RoomSelection room in roomSelectionList)
                {
                    foreach (RoomDetails room1 in roomList)
                    {
                        if (room.BookingID == bookingID && room.BookingStatus == BookingStatus.Booked && room1.RoomID == room.RoomID)
                        {
                            flag1 = true;
                            Console.WriteLine($"  {room.SelectionID}  |  {room.BookingID}  |  {room.RoomID}  |  {room.StayingDateFrom}  |  {room.StayingDateTo}  |  {room.Price}  |  {room.NumberOfDays}  |  {room.BookingStatus}");
                        }
                    }
                }
                if (flag1)
                {
                    System.Console.WriteLine("Invalid Booking Id");
                }
            }
        }

        public static void WalletRecharge()
        {
            // Ask the customer whether he wish to recharge the wallet.
            Console.Write("Do you want to recharge? yes/no : ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                // If “Yes” then ask for the amount to be recharged
                Console.Write("Enter the amount ");
                double amount = double.Parse(Console.ReadLine());
                if (amount > 0)
                {
                    // update the amount in the wallet and display the updated wallet balance.
                    currentUser.WalletRecharge(amount);
                    Console.WriteLine($"Total amount in the Wallet :  {currentUser.WalletBalance}");
                }
                else
                {
                    Console.WriteLine("Enter the amount in Positive above 0");
                }
            }
        }

        public static void ShowWalletBalnce()
        {
            System.Console.WriteLine("Updated wallet balance " + currentUser.WalletBalance);
        }
        public static void Exit()
        {
            System.Console.WriteLine("Exit...!");
        }
    }
}