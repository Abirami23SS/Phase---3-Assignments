using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CafeteriaApplication
{
    public class UserDetails : PersonalDetails, IBalance
    {
        // •	UserID (Auto – SF1001)
        // •	WorkStationNumber
        // •	Field: _balance
        // •	Read only property: WalletBalance.
        private static int s_userID = 1000;
        public string UserID { get; }
        public string WorkStationNumber { get; set; }
        public double _balance { get; set; }

        public double WalletBalance { get { return _balance; } }

        public UserDetails(string workStation, double walletBalance, string name, string fatherName, Gender gender, long mobile, string mailID)
        : base(name, fatherName, gender, mobile, mailID)
        {
            s_userID++;
            UserID = "SF" + s_userID;
            WorkStationNumber = workStation;
            _balance = walletBalance;
        }

        public UserDetails(string users)
        {
            string[] values = users.Split(",");
            s_userID = int.Parse(values[0].Remove(0, 2));
            UserID = values[0];
            WorkStationNumber = values[1];
            _balance = double.Parse(values[2]);
        }
        public void WalletRecharge(double amount)
        {
            _balance += amount;
        }

        public void DeductBalance(double amount)
        {
            _balance -= amount;
        }

    }
}