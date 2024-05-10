using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public interface IBalance
    {
         double  Balance {get;}

        void WalletRecharge(double amount);

        void Deductbalance(double amount);

    }
}