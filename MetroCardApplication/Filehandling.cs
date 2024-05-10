using System;
using System.Collections.Generic;
using System.IO;

namespace MetroCardApplication
{
    public class Filehandling
    {
        public static void Create()
        {
            if (!Directory.Exists("MetroCardApplication"))
            {
                System.Console.WriteLine("creating folder");
                Directory.CreateDirectory("MetroCardApplication");
            }
            if (!File.Exists("MetroCardApplication/UserDetails.csv"))
            {
                System.Console.WriteLine("creating file");
                File.Create("MetroCardApplication/UserDetails.csv").Close();
            }
            if (!File.Exists("MetroCardApplication/TravelDetails.csv"))
            {
                System.Console.WriteLine("creating file");
                File.Create("MetroCardApplication/TravelDetails.csv").Close();
            }
            if (!File.Exists("MetroCardApplication/TicketFairDetails.csv"))
            {
                System.Console.WriteLine("creating file");
                File.Create("MetroCardApplication/TicketFairDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string[] user = new string[Operation.userList.Count];
            for (int i = 0; i < Operation.userList.Count; i++)
            {
                user[i] = Operation.userList[i].CardNumber + "," + Operation.userList[i].UserName + "," + Operation.userList[i].PhoneNumber + "," + Operation.userList[i].Balance;
            }
            File.WriteAllLines("MetroCardApplication/UserDetails.csv", user);
            string[] travel = new string[Operation.travelList.Count];
            for (int i = 0; i < Operation.travelList.Count; i++)
            {
                travel[i] = Operation.travelList[i].TravelID + "," + Operation.travelList[i].CardNumber + "," + Operation.travelList[i].FromLocation + "," + Operation.travelList[i].ToLocation + "," + Operation.travelList[i].Date.ToString("dd/MM/yyyy") + "," + Operation.travelList[i].TravelCost;
            }
            File.WriteAllLines("MetroCardApplication/TravelDetails.csv", travel);
            string[] ticket = new string[Operation.ticketList.Count];
            for (int i = 0; i < Operation.ticketList.Count; i++)
            {
                ticket[i] = Operation.ticketList[i].TicketID + "," + Operation.ticketList[i].FromLocation + "," + Operation.ticketList[i].ToLocation + "," + Operation.ticketList[i].TicketPrice;
            }
            File.WriteAllLines("MetroCardApplication/TicketFairDetails.csv", ticket);
        }

        public static void ReadToCsv()
        {
            string[] user = File.ReadAllLines("MetroCardApplication/UserDetails.csv");
            foreach (string users in user)
            {
                UserDetails user1 = new UserDetails(users);
                Operation.userList.Add(user1);
            }
            string[] travel = File.ReadAllLines("MetroCardApplication/TravelDetails.csv");
            foreach (string travels in travel)
            {
                TravelDetails travel1 = new TravelDetails(travels);
                Operation.travelList.Add(travel1);
            }
            string[] ticket = File.ReadAllLines("MetroCardApplication/TicketFairDetails.csv");
            foreach (string tickets in ticket)
            {
                TicketFairDetails ticket1 = new TicketFairDetails(tickets);
                Operation.ticketList.Add(ticket1);
            }
        }
    }
}