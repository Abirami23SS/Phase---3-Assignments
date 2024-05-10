using System;
using System.IO;
namespace HotelManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            FileHandling.Create();
            // FileHandling.ReadToCSV();
            Operation.AddDefaultData();
            FileHandling.WriteToCSV();
            Operation.MainMenu();

        }
    }
}