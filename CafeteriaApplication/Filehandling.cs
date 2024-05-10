using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaApplication
{
    public class Filehandling
    {
        public static void Create()
        {
            if (!Directory.Exists("CafeteriaApplication"))
            {
                Console.WriteLine("Creating folder");
                Directory.CreateDirectory("CafeteriaApplication");
            }
            if (!File.Exists("CafeteriaApplication/UserDetails.csv"))
            {
                Console.WriteLine("Creating file for user");
                File.Create("CafeteriaApplication/UserDetails.csv").Close();
            }
            if (!File.Exists("CafeteriaApplication/OrderDetails.csv"))
            {
                Console.WriteLine("Creating file for donation");
                File.Create("CafeteriaApplication/OrderDetails.csv").Close();
            }
            if (!File.Exists("CafeteriaApplication/FoodDetails.csv"))
            {
                Console.WriteLine("Creating file for donation");
                File.Create("CafeteriaApplication/FoodDetails.csv").Close();
            }
            if (!File.Exists("CafeteriaApplication/CartItem.csv"))
            {
                Console.WriteLine("Creating file for donation");
                File.Create("CafeteriaApplication/CartItem.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string[] user = new string[Operation.userList.Count];
            for (int i = 0; i < Operation.userList.Count; i++)
            {
                user[i] = Operation.userList[i].UserID + "," + Operation.userList[i].WorkStationNumber + "," + Operation.userList[i].WalletBalance + "," + Operation.userList[i].Name + "," + Operation.userList[i].FatherName + "," + Operation.userList[i].Gender + "," + Operation.userList[i].Mobile + "," + Operation.userList[i].MailID;
            }
            File.WriteAllLines("CafeteriaApplication/UserDetails.csv", user);
            string[] order = new string[Operation.orderList.Count];
            for (int i = 0; i < Operation.orderList.Count; i++)
            {
                order[i] = Operation.orderList[i].OrderId + "," + Operation.orderList[i].UserID + "," + Operation.orderList[i].OrderDate.ToString("dd/MM/yyyy") + "," + Operation.orderList[i].TotalPrice + "," + Operation.orderList[i].OrderStatus;
            }
            File.WriteAllLines("CafeteriaApplication/OrderDetails.csv", order);
            string[] food = new string[Operation.foodList.Count];
            for (int i = 0; i < Operation.foodList.Count; i++)
            {
                food[i] = Operation.foodList[i].FoodID + "," + Operation.foodList[i].FoodName + "," + Operation.foodList[i].FoodPrice + "," + Operation.foodList[i].AvailableQuantity;
            }
            File.WriteAllLines("CafeteriaApplication/FoodDetails.csv", food);
            string[] cart = new string[Operation.cartList.Count];
            for (int i = 0; i < Operation.cartList.Count; i++)
            {
                cart[i] = Operation.cartList[i].ItemID + "," + Operation.cartList[i].OrderID + "," + Operation.cartList[i].FoodID + "," + Operation.cartList[i].OrderPrice + "," + Operation.cartList[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaApplication/CartItem.csv", cart);
        }

        public static void ReadToCSV()
        {
            string[] user=File.ReadAllLines("CafeteriaApplication/UserDetails.csv");
            foreach(string users in user)
            {
                UserDetails user1=new UserDetails(users);
                Operation.userList.Add(user1);
            }
            string[] order=File.ReadAllLines("CafeteriaApplication/OrderDetails.csv");
            foreach(string orders in order)
            {
                OrderDetails order1=new OrderDetails(orders);
                Operation.orderList.Add(order1);
            }
            string[] food=File.ReadAllLines("CafeteriaApplication/FoodDetails.csv");
            foreach(string foods in food)
            {
                FoodDetails food1=new FoodDetails(foods);
                Operation.foodList.Add(food1);
            }
            string[] cart=File.ReadAllLines("CafeteriaApplication/CartItem.csv");
            foreach(string carts in cart)
            {
                CartItem cart1=new CartItem(carts);
                Operation.cartList.Add(cart1);
            }
        }
    }
}