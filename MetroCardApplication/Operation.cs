using System;
using System.Collections.Generic;

namespace MetroCardApplication
{
    public class Operation
    {
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        public static CustomList<TravelDetails> travelList = new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketList = new CustomList<TicketFairDetails>();
        public static UserDetails currentUser;

        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravi", 23456789, 1000);
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Chandran", 987654, 2000);
            userList.Add(user2);

            TravelDetails travel1 = new TravelDetails(user1.CardNumber, "Airpot", "Egmore", new DateTime(2023, 10, 10), 55);
            travelList.Add(travel1);
            TravelDetails travel2 = new TravelDetails(user1.CardNumber, "Egmore", "koyambedu", new DateTime(2023, 09, 20), 32);
            travelList.Add(travel2);
            TravelDetails travel3 = new TravelDetails(user2.CardNumber, "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 25);
            travelList.Add(travel3);
            TravelDetails travel4 = new TravelDetails(user2.CardNumber, "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);
            travelList.Add(travel4);

            TicketFairDetails ticket1 = new TicketFairDetails("Airpot", "Egmore", 55);
            ticketList.Add(ticket1);
            TicketFairDetails ticket2 = new TicketFairDetails("Airpot", "Koyambedu", 25);
            ticketList.Add(ticket2);
            TicketFairDetails ticket3 = new TicketFairDetails("Alandur", "Egmore", 25);
            ticketList.Add(ticket3);
            TicketFairDetails ticket4 = new TicketFairDetails("Koyambedu", "Egmore", 32);
            ticketList.Add(ticket4);
            TicketFairDetails ticket5 = new TicketFairDetails("Vadapalani", "Egmore", 45);
            ticketList.Add(ticket5);
            TicketFairDetails ticket6 = new TicketFairDetails("Arumbakam", "Egmore", 25);
            ticketList.Add(ticket6);

            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"  {user.UserName}  |  {user.PhoneNumber}  |  {user.Balance}");
            }
            foreach (TravelDetails travel in travelList)
            {
                System.Console.WriteLine($"  {travel.TravelID}  |  {travel.CardNumber}  |  {travel.FromLocation}  |  {travel.ToLocation}  |  {travel.Date}  |  {travel.TravelCost}");
            }
            foreach (TicketFairDetails ticket in ticketList)
            {
                System.Console.WriteLine($"  {ticket.TicketID}  |  {ticket.FromLocation}  |  {ticket.ToLocation}  |  {ticket.TicketPrice}");
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("Application for Metro Card");
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.CustomerRegistartion  \n2.LoginUser  \n3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine("Registration selected");
                            CustomerRegistartion();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Login selected");
                            LoginUser();
                            break;
                        }

                    case 3:
                        {
                            //Console.WriteLine("Exit Selected");
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }

        public static void CustomerRegistartion()
        {
            Console.WriteLine("New User Registration");
            Console.Write("Enter UserName : ");
            string name = Console.ReadLine();
            Console.Write("Enter phone number : ");
            long phoneNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter balance : ");
            double balance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(name, phoneNumber, balance);
            userList.Add(user);
            Console.WriteLine("Registered successfully " + user.CardNumber);
        }

        public static void LoginUser()
        {
            Console.WriteLine("Enter card number  : ");
            string cardNumber = Console.ReadLine().ToUpper();
            currentUser = BinarySearch.BinarySearchLogin(cardNumber);
            bool flag = true;
            if (currentUser != null)
            {
                Console.WriteLine("Logged in successfully");
                flag = false;
                SubMenu();

            }
            if (flag)
            {
                Console.WriteLine("Invalid card number");
            }
        }

        public static void SubMenu()
        {

            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.Balance Check  2.Recharge  3.viewTravelhistory  4.Travel  5.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine(");
                            BalanceCheck();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("");
                            Recharge();
                            break;
                        }
                    case 3:
                        {
                            //Console.WriteLine("");
                            ViewtravelHistory();
                            break;
                        }
                    case 4:
                        {
                            //Console.WriteLine("");
                            Travel();
                            break;
                        }
                    case 5:
                        {
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }

        public static void BalanceCheck()
        {
            foreach (UserDetails user in userList)
            {
                if (currentUser.CardNumber == user.CardNumber)
                {
                    System.Console.WriteLine("Balance amount " + currentUser.Balance);
                }
            }
        }

        public static void Recharge()
        {
            System.Console.WriteLine("Enter amount to be recharged ");
            double amount = double.Parse(Console.ReadLine());
            currentUser.WalletRecharge(amount);
            Console.WriteLine("Recharge Successfull");
        }

        public static void ViewtravelHistory()
        {
            bool flag = true;
            Console.WriteLine("Enter card number  : ");
            string cardNumber = Console.ReadLine().ToUpper();
            TravelDetails currentUser = BinarySearch.BinarySearchView(cardNumber);
            if (currentUser != null)
            {
                flag = false;
                Console.WriteLine($"  {currentUser.TravelID}  |  {currentUser.CardNumber}  |  {currentUser.FromLocation}  |  {currentUser.ToLocation}  |  {currentUser.Date}  |  {currentUser.TravelCost}");
            }
            if (flag)
            {
                System.Console.WriteLine("No History");
            }
        }

        public static void Travel()
        {
            //show the ticket fair details where the user wishes to travel
            foreach (TicketFairDetails ticket1 in ticketList)
            {
                System.Console.WriteLine($"  {ticket1.TicketID}  |  {ticket1.FromLocation}  |  {ticket1.ToLocation}  |  {ticket1.TicketPrice}");
            }
            double total = 0;
            System.Console.WriteLine("Enter the ticket ID ");
            string ticketID = Console.ReadLine();
            TicketFairDetails ticket = BinarySearch.BinarySearchTravel(ticketID);
            if (ticket != null)
            {
                if (currentUser.Balance >= ticket.TicketPrice)
                {
                    total += ticket.TicketPrice;
                    currentUser.Deductbalance(total);
                    TravelDetails travel = new TravelDetails(currentUser.CardNumber, ticket.FromLocation, ticket.ToLocation, DateTime.Today, total);
                    travelList.Add(travel);
                    Console.WriteLine("Travel successfully");
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                    Console.WriteLine("Are you willing to recharge");
                    string option = Console.ReadLine();
                    if (option == "yes")
                    {
                        double amount = double.Parse(Console.ReadLine());
                        currentUser.WalletRecharge(amount);
                    }
                }
            }
        }


        public static void Exit()
        {
            System.Console.WriteLine("Exit....!");
        }
    }
}