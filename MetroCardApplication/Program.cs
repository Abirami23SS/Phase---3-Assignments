using System;
namespace MetroCardApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            Filehandling.Create();
            Filehandling.ReadToCsv();
            //Operation.AddDefaultData();
            Operation.MainMenu();
            Filehandling.WriteToCSV();
        }
    }
}