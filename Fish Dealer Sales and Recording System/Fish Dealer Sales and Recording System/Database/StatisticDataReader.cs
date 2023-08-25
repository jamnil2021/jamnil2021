using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class StatisticDataReader : DatabaseLocation
    {
        private string query;
        public DataTable StatisticData(DateTime fromDate, DateTime toDate)
        {
            query = "SELECT Date, KindofFish AS Variety, IIF(COUNT(NoofTub)>0, NoofTub, 0) + (SELECT IIF(COUNT(NoofTub)>0,NoofTub,0) FROM tblTaxCommission WHERE Date >= @fromDate AND Date <= @toDate) AS Bucket, IIF(COUNT(NoofKilo)>0, NoofKilo, 0) + (SELECT IIF(COUNT(NoofKilo)>0,NoofKilo,0) FROM tblTaxCommission WHERE Date >= @fromDate AND Date <= @toDate) AS Kilo FROM tblCostumerData AS DataCos WHERE Date >= @fromDate AND Date <= @toDate";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@fromDate", fromDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@toDate", toDate.ToString("yyyy-MM-dd"));
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

        public DataTable VarietyData(DateTime fromDate, DateTime toDate)
        {
            query = "SELECT DISTINCT KindofFish AS Variety FROM tblCostumerData WHERE Date >= @fromDate AND Date <= @toDate";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@fromDate", fromDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@toDate", toDate.ToString("yyyy-MM-dd"));
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

        public DataTable DummyStatistic()
        {
            query = @"SELECT * FROM dummyStatistic";
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
