using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaApplication
{
    public interface IBalance
    {
        //  Properties: WalletBalance
        // Method: WalletRecharge, DeductAmount
        public double WalletBalance { get; }

        void WalletRecharge(double amount);

        void DeductBalance(double amount);
    }
}