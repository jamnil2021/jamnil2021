using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class DatabaseLocation
    {
        private static string ExcelPath = @"C:\Users\" + Environment.UserName + @"\Documents\Data\Excel File\";

        // List for Tables
        public List<string> SQLiteCreateTable = new List<string>();

        //Path of Database 
        public static DirectoryInfo directory = new DirectoryInfo(@"C:\Users\" + Environment.UserName + @"\Documents\Data\Database\");

        public static DirectoryInfo directoryExcel = new DirectoryInfo(@"C:\Users\" + Environment.UserName + @"\Documents\Data\Excel File\");

        //Locate the Database that created and Static connection 
        public static string connectionString = "Data Source =" + directory + "InventoryDatabase.sqlite3; Version = 3;";

        // SQLiteConnection
        // Create Inventory Database 
        public SQLiteConnection connection = new SQLiteConnection(connectionString);

    }
}
