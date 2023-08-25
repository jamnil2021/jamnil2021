using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class CreateDatabaseTable : DatabaseLocation
    {
        public CreateDatabaseTable()
        {
            if (!Directory.Exists(directory.ToString()))
            {
                directory.Create();

              
                if (!File.Exists(directory + "InventoryDatabase.sqlite3"))
                {
                    // Create Inventory Database
                    SQLiteConnection.CreateFile(directory + "InventoryDatabase.sqlite3");

                    // Weekly Table
                    SQLiteCreateTable.Add(@"CREATE TABLE tblCostumerData (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                Date VARCHAR(30) NOT NULL,
                                Vendor VARCHAR(30) NOT NULL,
                                KindofFish VARCHAR(50) NOT NULL,
                                NoofTub REAL NOT NULL,
                                NoofKilo REAL NOT NULL,
                                UnitKiloPrice REAL NOT NULL,
                                UnitTubPrice REAL NOT NULL,
                                TotalPrice REAL NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblDepartureRecord (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                CastOff VARCHAR(30) NOT NULL,
                                Docking VARCHAR(30) NOT NULL,
                                BoatName VARCHAR(30) NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblCrewRecord (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT,
                                CrewName VARCHAR(50) NOT NULL, 
                                Position VARCHAR(50) NOT NULL, 
                                Available NUMERIC,
                                Salary REAL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblSummary (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                Date TEXT NOT NULL,
                                IDClass TEXT NOT NULL,
                                BoatName VARCHAR(50) NOT NULL,
                                GrossProfit REAL NOT NULL,
                                Salary REAL NOT NULL,
                                Operational REAL NOT NULL,
                                Maintenance REAL NOT NULL,
                                Merchandise REAL NOT NULL,
                                Tax REAL NOT NULL,
                                TotalExpenses REAL NOT NULL,
                                Commission REAL NOT NULL,
                                Handling REAL NOT NULL,
                                Unloading REAL NOT NULL,
                                NetIncome REAL NOT NULL
                    )");   

                    SQLiteCreateTable.Add(@"CREATE TABLE tblExpensesRecord (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                Category TEXT NOT NULL,
                                Items VARCHAR(50) NOT NULL,
                                Price REAL NOT NULL     
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblFishImportRecord (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                KindofFish VARCHAR(50) NOT NULL,
                                NoofTubs REAL NOT NULL,    
                                NoofKilos REAL NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblUserAccount (Username VARCHAR(30) PRIMARY KEY,
                                Password VARCHAR(30) NOT NULL,
                                Status VARCHAR(15)
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblCountDate (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                Week REAL NOT NULL,
                                Month REAL NOT NULL,
                                Year REAL NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblProcessHistory (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                Date REAL NOT NULL,
                                ProcessName TEXT NOT NULL,
                                DateFrom TEXT NOT NULL,
                                DateTo TEXT NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE CategoryExpenses (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                Category TEXT NOT NULL,
                                ItemName TEXT UNIQUE NOT NULL
                    )");

                    // Fish Species Table 
                    SQLiteCreateTable.Add(@"CREATE TABLE VarietySpecies (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                VarietyofFish TEXT UNIQUE NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblTax (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                Tax REAL,
                                Commission REAL,
                                Unloading REAL,
                                Handling REAL
                    )");

                    // Create Table
                    foreach (string tableName in SQLiteCreateTable)
                    {
                        using (SQLiteCommand command = new SQLiteCommand(tableName, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    //Declare default username and password
                    LoginAccountConnector account = new LoginAccountConnector();
                    account.AccountDataInsert("admin", "admin", "Owner");
                }
            }
        }
    }
}
