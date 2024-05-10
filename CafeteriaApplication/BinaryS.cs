using System;
using System.Collections.Generic;

namespace CafeteriaApplication
{
    public class BinaryS
    {
        public string UserID { get; set; }

        public static UserDetails BinarySearch(string searchElement)
        {
            CustomList<UserDetails> userList=Operation.userList;
            int left = 0; int right = userList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                if (userList[middle].UserID == searchElement)
                {
                    return userList[middle];
                }
                else if (string.Compare(userList[middle].UserID, searchElement) < 0)
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
        public static OrderDetails BinarySearchCancel(string searchElement)
        {
            CustomList<OrderDetails> orderList =Operation.orderList;
            int left = 0; int right = orderList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                if (orderList[middle].UserID == searchElement)
                {
                    return orderList[middle];
                }
                else if (string.Compare(orderList[middle].UserID, searchElement) < 0)
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

          public static OrderDetails BinarySearchModify(string searchElement)
        {
            CustomList<OrderDetails> orderList=Operation.orderList;
            int left = 0; int right = orderList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                if (orderList[middle].UserID == searchElement)
                {
                    return orderList[middle];
                }
                else if (string.Compare(orderList[middle].UserID, searchElement) < 0)
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