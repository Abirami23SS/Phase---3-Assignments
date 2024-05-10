using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CafeteriaApplication
{
    public class Operation
    {
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        public static CustomList<CartItem> cartList = new CustomList<CartItem>();

        public static UserDetails currentUser;

        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("WS101", 400, "RaviChandran", "Ettapparajan", Gender.Male, 345678998, "ravi@gmail.com");
            userList.Add(user1);
            UserDetails user2 = new UserDetails("WS105", 500, "Baskaran", "Sethurajan", Gender.Male, 876543980, "baskaran@gmail.com");
            userList.Add(user2);

            OrderDetails order1 = new OrderDetails(user1.UserID, new DateTime(2023,04,23), 70, OrderStatus.Ordered);
            orderList.Add(order1);
            OrderDetails order2 = new OrderDetails(user2.UserID, new DateTime(2023,04,22), 100, OrderStatus.Ordered);
            orderList.Add(order2);

            CartItem cart1 = new CartItem(order1.OrderId, "FID101", 20, 1);
            cartList.Add(cart1);
            CartItem cart2 = new CartItem(order1.OrderId, "FID103", 10, 1);
            cartList.Add(cart2);
            CartItem cart3 = new CartItem(order1.OrderId, "FID105", 40, 1);
            cartList.Add(cart3);
            CartItem cart4 = new CartItem(order2.OrderId, "FID103", 10, 1);
            cartList.Add(cart4);
            CartItem cart5 = new CartItem(order2.OrderId, "FID104", 50, 1);
            cartList.Add(cart5);
            CartItem cart6 = new CartItem(order2.OrderId, "FID105", 50, 1);
            cartList.Add(cart6);

            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            foodList.Add(food1);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            foodList.Add(food2);
            FoodDetails food3 = new FoodDetails("Biscuit", 10, 100);
            foodList.Add(food3);
            FoodDetails food4 = new FoodDetails("Juice", 50, 100);
            foodList.Add(food4);
            FoodDetails food5 = new FoodDetails("Puff", 40, 100);
            foodList.Add(food5);
            FoodDetails food6 = new FoodDetails("Milk", 10, 100);
            foodList.Add(food6);
            FoodDetails food7 = new FoodDetails("Popcorn", 20, 20);
            foodList.Add(food7);

            foreach (UserDetails user in userList)
            {
                Console.WriteLine($"  {user.UserID}  |  {user.WorkStationNumber}  |  {user.WalletBalance}  |  {user.Name}  |  {user.FatherName}  |  {user.Gender}  |  {user.Mobile}  |  {user.MailID}");
            }
            foreach (OrderDetails order in orderList)
            {
                Console.WriteLine($" {order.OrderId}  |  {order.UserID}  |  {order.OrderDate.ToString("dd/MM/yyyy")}  |  {order.TotalPrice}  |  {order.OrderStatus}");
            }
            foreach (CartItem cart in cartList)
            {
                Console.WriteLine($"  {cart.ItemID}  |  {cart.OrderID}  |  {cart.FoodID}  |  {cart.OrderPrice}  |  {cart.OrderQuantity}");
            }
            foreach (FoodDetails food in foodList)
            {
                Console.WriteLine($"  {food.FoodID}  |  {food.FoodName}  |  {food.FoodPrice}  |  {food.AvailableQuantity}");
            }
        }

        public static void MainMenu()
        {
            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.UserRegistration  2.UserLogin  3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //Console.WriteLine("Registration selected");
                            UserRegistartion();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Login selected");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            //Console.WriteLine("Exit Selected");
                            flag = false;
                            Exit();
                            break;
                        }
                }
            } while (flag);
        }

        public static void UserRegistartion()
        {
            Console.WriteLine("Enter User Details");
            Console.Write("Enter name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Fathername : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter  Mobile : ");
            long mobile = long.Parse(Console.ReadLine());
            Console.Write("Enter  Mail ID : ");
            string mailID = Console.ReadLine();
            Console.Write("Enter Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter WorkStationNumber : ");
            string workStation = Console.ReadLine();
            Console.Write("Enter Balance : ");
            double _balance = double.Parse(Console.ReadLine());

            UserDetails newUser = new UserDetails(workStation, _balance, name, fatherName, gender, mobile, mailID);
            userList.Add(newUser);
            Console.WriteLine("Registered successfully " + newUser.UserID);
        }

        public static void UserLogin()
        {
            Console.WriteLine("Enter user Id  : ");
            string userID = Console.ReadLine();
            currentUser = BinaryS.BinarySearch(userID);
            if (currentUser != null)
            {
                Console.WriteLine("Logged in successfull");
                SubMenu();
            }
            else
            {
                Console.WriteLine("Invalid User Id..");
            }
        }
        public static void SubMenu()
        {
            // a.    Show My Profile
            // b.	 Food Order
            // c.	 Modify Order
            // d.	 Cancel Order
            // e.	 Order History
            // f.	 Wallet Recharge
            // g.	Show WalletBalance
            // h.	 Exit

            int choice;
            bool flag = true;
            do
            {
                Console.WriteLine("1.ShowMyProfile  2.FoodOrder  3.ModifyOrder  4.cancelOrder  5.OrderHistory  6.WalletRecharge  7.ShowWalletBalance  8.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            flag = false;
                            break;
                        }
                }

            } while (flag);
        }

        public static void ShowMyProfile()
        {
            foreach (UserDetails user in userList)
            {
                if (currentUser.UserID == user.UserID)
                {
                   
                    Console.WriteLine($"  {user.UserID}  |  {user.WorkStationNumber}  |  {user.WalletBalance}  |  {user.Name}  |  {user.FatherName}  |  {user.Gender}  |  {user.Mobile}  |  {user.MailID}");
                }
            }
        }

        public static void FoodOrder()
        {

            //1.	Create a temporary local carItemtList.
            CustomList<CartItem> localCartList = new CustomList<CartItem>();
            //2.	Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
            OrderDetails order = new OrderDetails(currentUser.UserID, DateTime.Today, 0, OrderStatus.Initiated);
            //3.	Ask the user to pick a product using FoodID, quantity required and calculate price of food.
            int totalPrice = 0;
            int total;
            string option = "";
            foreach (FoodDetails food in foodList)
            {
                Console.WriteLine($"  {food.FoodID}  |  {food.FoodName}  |  {food.FoodPrice}  |  {food.AvailableQuantity}");
            }
            do
            {
                Console.WriteLine("Enter food Id to buy..");
                string foodID = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter quantity ");
                int quantity = int.Parse(Console.ReadLine());
                bool flag = true;
                foreach (FoodDetails food in foodList)
                {
                    if (foodID == food.FoodID)
                    {

                        if (quantity <= food.AvailableQuantity)
                        {
                            //4.	If the food and quantity available, reduce the quantity from the food object’s “AvailableQuantity” 
                            flag = false;
                            total = quantity * food.FoodPrice;
                            food.AvailableQuantity -= quantity;
                            totalPrice += total;
                            CartItem newCart = new CartItem(order.OrderId, foodID, total, quantity);
                            localCartList.Add(newCart);
                        }
                        else
                        {
                            System.Console.WriteLine("Quantity not available");
                        }
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid food ID");
                }

                System.Console.WriteLine("whether he want to pick another product. ");
                option = Console.ReadLine();
            } while (option == "yes");
            //10.	Ask the user whether he confirm the wish list to purchase. .
            Console.WriteLine(" whether he confirm the wish list to purchase");
            string option1 = Console.ReadLine();
            if (option1 == "yes")
            {
                bool temp = true;
                do
                {
                    //Calculate the total price of the food items selected using the local CartItemList information and 
                    //check the balance from the user details whether it has sufficient balance to purchase.
                    if (totalPrice <= currentUser.WalletBalance)
                    {
                        temp = true;
                        cartList.AddRange(localCartList);
                        order.TotalPrice = totalPrice;
                        order.OrderStatus = OrderStatus.Ordered;
                        currentUser.DeductBalance(totalPrice);
                        orderList.Add(order);
                        //16.	Show “Order placed successfully, and OrderID is OID1001”.
                        System.Console.WriteLine("Order Placed Successfully " + order.OrderId);
                        break;
                    }
                    else
                    {
                        //17.	If he doesn’t have enough balance show 
                        //“In sufficient balance to purchase.” Ask him “Are you willing to recharge
                        System.Console.WriteLine("In sufficient balance to purchase");
                        System.Console.WriteLine("Are you willing to recharge");
                        string choice = Console.ReadLine();
                        if (choice == "yes")
                        {
                            temp = true;
                            System.Console.WriteLine("Enter the amount to be recharged");
                            double amount = double.Parse(Console.ReadLine());
                            currentUser.WalletRecharge(amount);
                            System.Console.WriteLine("Current Balance " + currentUser.WalletBalance);
                        }
                        else
                        {
                            temp = true;
                            foreach (CartItem cart in cartList)
                            {
                                foreach (FoodDetails food in foodList)
                                {
                                    if (food.FoodID == cart.FoodID)
                                    {
                                        food.AvailableQuantity += cart.OrderQuantity;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                } while (temp);
            }

            else
            {
                //If he says “No”  then traverse the local CartItemList and 
                //get the Items one by one and reverse the quantity to the FoodItem’s objects in the foodList
                foreach (CartItem cart in cartList)
                {
                    foreach (FoodDetails food in foodList)
                    {
                        if (food.FoodID == cart.FoodID)
                        {
                            food.AvailableQuantity += cart.OrderQuantity;
                            break;
                        }
                    }
                }

            }

        }

        public static void ModifyOrder()
        {
            //1.Show the Order details of current logged in user to pick an Order detail by using OrderID and whose status is “Ordered”. 
            bool isFlag = true;
            foreach (OrderDetails order in orderList)
            {
                //Check whether the order details is present. If yes then,
                if (order.OrderStatus == OrderStatus.Ordered && order.UserID == currentUser.UserID)
                {
                    isFlag = false;
                    Console.WriteLine($" {order.OrderId}  |  {order.UserID}  |  {order.OrderDate}  |  {order.TotalPrice}  |  {order.OrderStatus}");
                }
            }
            if (isFlag)
            {
                System.Console.WriteLine("No cancel order");
            }
            if (!isFlag)
            {
                //Show list of Cart Item details
                bool flag = true;
                foreach (CartItem cart in cartList)
                {
                    Console.WriteLine($"  {cart.ItemID}  |  {cart.OrderID}  |  {cart.FoodID}  |  {cart.OrderPrice}  |  {cart.OrderQuantity}");
                }
                // ask the user to pick an Item id.
                System.Console.WriteLine("Enter order ID to modify ");
                string orderId = Console.ReadLine();
                foreach (OrderDetails order in orderList)
                {
                    if (orderId == order.OrderId && order.OrderStatus == OrderStatus.Ordered)
                    {
                        foreach (CartItem cart in cartList)
                        {
                            if (cart.OrderID == orderId)
                            {
                                flag = false;
                                Console.WriteLine("Enter item ID");
                                string itemID = Console.ReadLine();
                                bool flag1 = true;
                                foreach (CartItem cart1 in cartList)
                                {
                                    //3.Ensure the ItemID is available 
                                    if (cart.ItemID == itemID)
                                    {
                                        flag1 = false;
                                        System.Console.WriteLine("Enter the new quantity of food");
                                        //ask the user to enter the new quantity of the food
                                        int newQuantity = int.Parse(Console.ReadLine());
                                        //.Calculate the Item price and update in the OrderPrice
                                        foreach (FoodDetails food in foodList)
                                        {
                                            if (food.FoodID == cart.FoodID)
                                            {
                                                if (food.AvailableQuantity >= newQuantity)
                                                {
                                                    //4.Calculate the total price of Items and update in Order details entry.

                                                    int finalCheck = newQuantity - cart.OrderQuantity;
                                                    if (finalCheck == 0)
                                                    {
                                                        System.Console.WriteLine("Same quantity entered");
                                                    }
                                                    else if (finalCheck < 0)
                                                    {
                                                        //reduce cart count
                                                        cart.OrderQuantity += finalCheck;
                                                        int returnAmount = -finalCheck * food.FoodPrice;
                                                        currentUser.WalletRecharge(returnAmount);
                                                        //increase food item stock count
                                                        food.AvailableQuantity += -finalCheck;
                                                        System.Console.WriteLine("Order modified successfully");
                                                    }
                                                    else
                                                    {
                                                        cart.OrderQuantity += finalCheck;
                                                        //if(currentUser.WalletBalance > r)
                                                        int returnAmount = finalCheck * food.FoodPrice;
                                                        currentUser.DeductBalance(returnAmount);
                                                        food.AvailableQuantity -= finalCheck;
                                                        System.Console.WriteLine("Order modified successfully");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Quantity not available");
                                                }
                                            }
                                        }
                                    }
                                }
                                if (flag1)
                                {
                                    System.Console.WriteLine("Invalid item");
                                }
                            }
                            if (flag)
                            {
                                System.Console.WriteLine("Invalid order ID");
                            }
                        }
                    }
                }
            }
        }

        public static void CancelOrder()
        {
            //1.	Show the Order details of the current user who’s Order status is “Ordered”.
            Console.WriteLine("Order Details");
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                // 3.	Check the OrderID is valid. If not, then show “Invalid OrderID”.
                if (currentUser.UserID == order.UserID && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($" {order.OrderId}  |  {order.UserID}  |  {order.OrderDate}  |  {order.TotalPrice}  |  {order.OrderStatus}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No order placed");
            }
            if (!flag)
            {
                // 2.	Ask the user to pick an OrderID to cancel.  
                System.Console.WriteLine("Enter the order id to cancel");
                string orderID = Console.ReadLine();

                foreach (OrderDetails order in orderList)
                {
                    if (order.OrderId == orderID && order.OrderStatus == OrderStatus.Ordered)
                    {
                        //temp = true;
                        //4.	If valid, then Return the Order total amount to current user. 
                        currentUser.WalletRecharge(order.TotalPrice);
                        // 5.	Return product orderQuantity to Foodtem list’s FoodQuantity. 
                        foreach (CartItem cart in cartList)
                        {
                            if (cart.OrderID == order.OrderId)
                            {
                                foreach (FoodDetails food in foodList)
                                {
                                    if (cart.FoodID == food.FoodID)
                                    {
                                        food.AvailableQuantity += cart.OrderQuantity;
                                        break;
                                    }
                                }
                            }
                        }
                        // 6.Change the OrderStatus as Cancelled.
                        order.OrderStatus = OrderStatus.Cancelled;
                        //7.Show “Order cancelled successfully” and product returned to cart.
                        Console.WriteLine("Order cancelled successfully and product returned to cart.");
                    }
                }
            }

        }


        public static void OrderHistory()
        {
            foreach (OrderDetails order in orderList)
            {
                if (currentUser.UserID == order.UserID)
                {
                    Console.WriteLine($" {order.OrderId}  |  {order.UserID}  |  {order.OrderDate}  |  {order.TotalPrice}  |  {order.OrderStatus}");
                }
            }
        }

        public static void WalletRecharge()
        {
            Console.WriteLine("Ask the customer whether he wish to recharge the wallet? ");
            string option = Console.ReadLine();
            if (option == "yes")
            {
                //2.If “Yes” then ask for the amount to be recharged and update the amount in the wallet and 
                //display the updated wallet balance.
                double amount = double.Parse(Console.ReadLine());
                if (amount > 0)
                {
                    currentUser.WalletRecharge(amount);
                    Console.WriteLine("Updated Balance : " + currentUser.WalletBalance);
                }
                else
                {
                    Console.WriteLine("Invalid Recharge amount");
                }
            }
        }

        public static void ShowWalletBalance()
        {
            Console.WriteLine(currentUser.WalletBalance);
        }

        public static void Exit()
        {
            Console.WriteLine("Exit...!");
        }
    }
}
