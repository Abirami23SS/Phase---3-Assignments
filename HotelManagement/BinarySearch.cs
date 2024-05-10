using System;
using System.Collections.Generic;


namespace HotelManagement
{
    public class BinarySearch
    {
        public string UserID { get; set; }

        public static UserRegistration BinarySearchLogin(string element)
        {
            CustomList<UserRegistration> userList = Operation.userList;
            int left = 0;
            int right = userList.Count - 1;
            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                if (userList[middle].UserID==element)
                {
                    return userList[middle];
                }
                else if (string.Compare(userList[middle].UserID, element) < 0)
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
