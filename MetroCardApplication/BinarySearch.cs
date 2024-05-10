using System;
using System.Collections.Generic;

namespace MetroCardApplication
{
    public class BinarySearch
    {
        public string CardNumber { get; set; }
        public static UserDetails BinarySearchLogin(string element)
        {
            CustomList<UserDetails> userList = Operation.userList;
            int left = 0;
            int right = userList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                if (userList[middle].CardNumber == element)
                {
                    return userList[middle];
                }
                else if (string.Compare(userList[middle].CardNumber, element) < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return null;
        }

         public static TravelDetails BinarySearchView(string element)
        {
            CustomList<TravelDetails> travelList=Operation.travelList;
            int left = 0;
            int right = travelList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                if (travelList[middle].CardNumber == element)
                {
                    return travelList[middle];
                }
                else if (string.Compare(travelList[middle].CardNumber, element) < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return null;
        }

          public static TicketFairDetails BinarySearchTravel(string element)
        {
            CustomList<TicketFairDetails> ticketList=Operation.ticketList;
            int left = 0;
            int right = ticketList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                if (ticketList[middle].TicketID == element)
                {
                    return ticketList[middle];
                }
                else if (string.Compare(ticketList[middle].TicketID, element) < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return null;
        }
    }
}