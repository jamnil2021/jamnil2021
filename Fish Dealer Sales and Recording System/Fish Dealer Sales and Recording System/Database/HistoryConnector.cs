using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class HistoryConnector : DatabaseLocation
    {
        private string query;

        public DataTable HistoryWeekRead()
        {
            query = "SELECT * FROM tblWeekHistory WHERE No = COUNT(No)";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
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

        public DataTable HistoryMonthRead()
        {
            query = "SELECT * FROM tblMonthHistory WHERE No = COUNT(No)";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection())
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
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

        public DataTable HistoryYearRead()
        {
            query = "SELECT * FROM tblCostumerData WHERE strftime('%W', Date) = strftime('%W', DATE()) AND strftime('%Y', Date) = strftime('%Y', DATE())";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
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
