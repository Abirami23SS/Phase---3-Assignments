using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class UserRegistration: PersonalDetails,IWalletManager
    {
        public double _balance{get; set;}
        public static int s_userID=1000;
        public string UserID{get;}
        public double WalletBalance{get {return _balance;}}

        public UserRegistration(string userName,long mobile,int aadharNumber,string address,FoodType foodType,Gender gender,double walletBalance)
        :base(userName,mobile,aadharNumber,address,foodType,gender)
        {
            s_userID++;
            UserID="SF"+s_userID;
            _balance=walletBalance;
        }

         public UserRegistration(string users)
        {
            string[] values=users.Split(",");
            s_userID=int.Parse(values[0].Remove(0,2));
            UserID=values[0];
            UserName=values[1];
            MobileNumber=long.Parse(values[2]);
            AadharNumber=int.Parse(values[3]);
            Address=values[4];
            FoodType=Enum.Parse<FoodType>(values[5]);
            Gender=Enum.Parse<Gender>(values[6]);
            _balance=double.Parse(values[7]);
        }

        public void WalletRecharge(double amount)
        {
            _balance+=amount;
        }
        public void DeductBalance(double amount)
        {
            _balance-=amount;
        }
    }
}