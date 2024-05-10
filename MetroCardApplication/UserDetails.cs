using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class UserDetails : PersonalDetails, IBalance
    {
        private static int s_cardNumber = 1000;
        public string CardNumber { get; }
        public double Balance { get; set; }

        public UserDetails(string name, long phoneNumber, double balance)
        : base(name, phoneNumber)
        {
            s_cardNumber++;
            CardNumber = "CMRL" + s_cardNumber;
            Balance = balance;
        }

        public UserDetails(string users)
        {
            string[] values = users.Split(",");
            s_cardNumber = int.Parse(values[0].Remove(0, 4));
            CardNumber = values[0];
            UserName = values[1];
            PhoneNumber = long.Parse(values[2]);
            Balance = double.Parse(values[3]);
        }

        public void WalletRecharge(double amount)
        {
            Balance += amount;
        }
        public void Deductbalance(double amount)
        {
            Balance -= amount;
        }
    }
}