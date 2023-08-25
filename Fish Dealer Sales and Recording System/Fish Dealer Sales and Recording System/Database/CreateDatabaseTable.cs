using System;
using System.Collections.Generic;
using System.Data;
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
                                DateGenerated TEXT,
                                Title VARCHAR(20),
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
                                TotalTubs REAL NOT NULL,    
                                NoofTubs REAL NOT NULL,    
                                NoofKilos REAL NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblTotalTubs (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                NoofTubs REAL NOT NULL
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
                                ItemName TEXT NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE CostumerName (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL
                    )");

                    // Fish Species Table 
                    SQLiteCreateTable.Add(@"CREATE TABLE VarietySpecies (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                VarietyofFish TEXT UNIQUE NOT NULL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblTax (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                Tax REAL,
                                Unloading REAL,
                                Handling REAL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE dummyStatistic (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                Variety TEXT,
                                NoofKilo REAL,
                                NoofTub REAL
                    )");

                    SQLiteCreateTable.Add(@"CREATE TABLE tblTaxCommission (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                IDClass TEXT NOT NULL,
                                Vendor VARCHAR(30) NOT NULL,
                                Date VARCHAR(30) NOT NULL,
                                Commission REAL NOT NULL,
                                KindofFish VARCHAR(50) NOT NULL,
                                NoofTub REAL NOT NULL,
                                NoofKilo REAL NOT NULL,
                                UnitKiloPrice REAL NOT NULL,
                                UnitTubPrice REAL NOT NULL,
                                TotalPrice REAL NOT NULL,
                                TotalCommission REAL NOT NULL
                    )");
                    
                    SQLiteCreateTable.Add(@"CREATE TABLE tblVesselName (No INTEGER PRIMARY KEY AUTOINCREMENT,
                                VesselName VARCHAR(50)
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
                    DataTableConnector dataTableConnector = new DataTableConnector();
                    SummaryPropertiesModel summaryProperties = new SummaryPropertiesModel();
                    summaryProperties.DateGenerated = Convert.ToDateTime("2000-01-27");
                    summaryProperties.Title = "Dummy";
                    summaryProperties.VesselName = "Dummy";
                    summaryProperties.GrossProfit = 0;
                    summaryProperties.Salary = 0;
                    summaryProperties.Operational = 0;
                    summaryProperties.Maintenance = 0;
                    summaryProperties.Merchandise = 0;
                    summaryProperties.Tax = 0;
                    summaryProperties.Commission = 0;
                    summaryProperties.Handling = 0;
                    summaryProperties.Unloading = 0;
                    dataTableConnector.InsertSummary(summaryProperties);

                    // Dummy Data for Graphs and DataTable
                    string[] fish = {"Milkfish", "Puffer Fish", "Yellowfin Tuna", "Leopard Coral Grouper", "Anchovy", "Red Snapper" };
                    int[] kilo = {120, 250, 30, 0, 100 };
                    int[] tubs = {10, 250, 100, 20, 30 };
                    string query = @"INSERT INTO dummyStatistic(Variety, NoofKilo, NoofTub)VALUES(@kindoffish, @noofkilo, @nooftub)";
                    for (int i = 0; i < fish.Length-1; i++)
                    {
                        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                        {
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@kindoffish", fish[i]);
                                command.Parameters.AddWithValue("@noofkilo", kilo[i]);
                                command.Parameters.AddWithValue("@nooftub", tubs[i]);
                                command.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }

                    //Create default username and password
                    LoginAccountConnector account = new LoginAccountConnector();
                    account.AccountDataInsert("admin", "admin", "Owner");
                }
            }
        }
    }
}
