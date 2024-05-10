using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaApplication
{
    public class CartItem
    {
        // •	ItemID (Auto - ITID101) 
        // •	OrderID
        // •	FoodID
        // •	OrderPrice
        // •	OrderQuantity
        private static int s_itemID=100;
        public string ItemID{get;}
        public string OrderID{get; set;}
        public string FoodID{get; set;}
        public int OrderPrice{get; set;}
        public int OrderQuantity{get; set;}

        public CartItem(string orderID,string foodID,int orderPrice,int orderQuantity)
        {
            s_itemID++;
            ItemID="ITID"+s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;
        }

        public CartItem(string carts)
        {
            string[] values=carts.Split(",");
            s_itemID=int.Parse(values[0].Remove(0,4));
            ItemID=values[0];
            OrderID=values[1];
            FoodID=values[2];
            OrderPrice=int.Parse(values[3]);
            OrderQuantity=int.Parse(values[4]);
        }
    }
}