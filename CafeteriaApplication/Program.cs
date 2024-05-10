using System;
using System.IO;
namespace CafeteriaApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            Filehandling.Create();
            Filehandling.ReadToCSV();
            //Operation.AddDefaultData();

            Operation.MainMenu();
            Filehandling.WriteToCSV();

        }
    }
}