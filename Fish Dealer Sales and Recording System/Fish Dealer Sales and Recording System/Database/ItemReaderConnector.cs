using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ItemReaderConnector : DatabaseLocation
    {
        private string query;

        // Return All Expenses Data
        public DataTable ExpensesCategory(string category)
        {
            query = "SELECT Category, ItemName FROM CategoryExpenses WHERE Category = @category";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@category",category.TrimEnd());
                        command.ExecuteNonQuery();
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                    connection.Close();
                }
                return table; 
            }
        }

        public DataTable ExpensesCategory()
        {
            query = "SELECT ItemName FROM CategoryExpenses";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                    connection.Close();
                }
                return table;
            }
        }

        public DataTable VarietyFish()
        {
            query = "SELECT VarietyofFish FROM VarietySpecies";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                    connection.Close();
                }
                return table;
            }
        }

        public DataTable VarietyFish(string Variety)
        {
            query = "SELECT VarietyofFish FROM VarietySpecies WHERE VarietyofFish LIKE '"+Variety+"%'";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                    connection.Close();
                }
                return table;
            }
        }

        public void VarietyInsert(string Variety)
        {
            query = "INSERT INTO VarietySpecies(VarietyofFish) VALUES (@variety)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@variety", Variety);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable CostumersName()
        {
            query = "SELECT Name FROM CostumerName";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                        connection.Close();
                    }
                }
                return table;
            }
        }
    }
}
