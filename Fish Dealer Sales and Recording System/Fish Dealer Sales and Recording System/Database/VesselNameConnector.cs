using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System.Database
{
    public class VesselNameConnector : DatabaseLocation
    {
        protected string query;
        public bool InsertVesselName(string vesselName)
        {
            query = "INSERT INTO tblVesselName(VesselName) VALUES(@vesselName)";
            bool Success = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@vesselName", vesselName);
                    Success = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return Success;
        }

        public bool DeleteVesselName(int No)
        {
            query = "DELETE FROM tblVesselName WHERE No = @no";
            bool Success = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@no", No);
                    Success = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return Success;
        }

        public DataTable RetrieveVesselName()
        {
            query = "SELECT * FROM tblVesselName ORDER BY No DESC";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            connection.Open();
                            adapter.Fill(table);
                            connection.Close();
                        }
                    }
                }
                return table;
            }
        }
    }
}
