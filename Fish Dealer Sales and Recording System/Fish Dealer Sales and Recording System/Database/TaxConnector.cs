using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class TaxConnector : DatabaseLocation
    {
        private string query;
        public DataTable TaxRead(string IDClass)
        {
            using (DataTable table = new DataTable())
            {
                query = "SELECT * FROM tblTax WHERE IDClass = @idclass";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@idclass",IDClass);
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

        public void TaxInsert(TaxPropertiesModel taxProperties)
        {
            query = "INSERT INTO tblTax (IDClass, Tax, Handling, Unloading) VALUES (@idclass, @tax, @handling, @unloading)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@tax", taxProperties.Tax);
                    command.Parameters.AddWithValue("@handling", taxProperties.Handling);
                    command.Parameters.AddWithValue("@unloading", taxProperties.Unloading);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void TaxUpdate(TaxPropertiesModel taxProperties)
        {
            query = "UPDATE tblTax SET Tax = @tax, Handling = @handling, Unloading = @unloading WHERE IDClass = @idclass";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@tax", taxProperties.Tax);
                    command.Parameters.AddWithValue("@handling", taxProperties.Handling);
                    command.Parameters.AddWithValue("@unloading", taxProperties.Unloading);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable TaxAvailableFish(string IDClass)
        {
            query = @"SELECT KindofFish FROM tblFishImportRecord WHERE IDClass = @idclass";
            using (DataTable table = new  DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@idclass", IDClass);
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
