using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class DateDepartureConnector : DatabaseLocation
    {
        private string query;

        public void InsertDate(DateDeparturePropertiesModel boatDeparture)
        {
            query = @"INSERT INTO tblDepartureRecord(IDClass, BoatName, CastOff, Docking) 
                    VALUES (@idclass, @Bname ,@cast, @dock)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", boatDeparture.GetIDNo);
                    command.Parameters.AddWithValue("@Bname", boatDeparture.VesselName);
                    command.Parameters.AddWithValue("@cast", boatDeparture.CastOff);
                    command.Parameters.AddWithValue("@dock", boatDeparture.Docking);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public DataTable ReadDate()
        {
            DataTable table = new DataTable();
            query = @"SELECT * FROM tblDepartureRecord";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    connection.Open();
                    adapter.Fill(table);
                    connection.Close();
                }
            }
            return table;
        }
        public void DeleteDate(string IDClass)
        {
            query = $@"DELETE FROM tblDepartureRecord WHERE IDClass = '{IDClass}'";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public void EditDate(DateDeparturePropertiesModel boatDeparture)
        {
            query = "UPDATE tblDepartureRecord SET CastOff = @cast, Docking = @dock WHERE IDClass = @idclass";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@cast", boatDeparture.CastOff);
                    command.Parameters.AddWithValue("@dock", boatDeparture.Docking);
                    command.Parameters.AddWithValue("@idclass", boatDeparture.IDClass);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable SearchDate(string vesselName)
        {
            query = "SELECT * FROM tblDepartureRecord WHERE BoatName LIKE @vesselName %";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@vesselName", vesselName);
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

        public int DateChecker(DateTime castOff, string boatName)
        {
            query = "SELECT COUNT(BoatName) FROM tblDepartureRecord WHERE BoatName = @bname AND CastOff = @cast";
            int result = 0;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@cast", castOff.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@bName", boatName);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetInt16(0);
                        }
                    }
                    connection.Close();
                }
            }
            return result;
        }
    }
}
