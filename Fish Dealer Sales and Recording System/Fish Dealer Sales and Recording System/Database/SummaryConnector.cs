using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class SummaryConnector : DatabaseLocation
    {
        private string query;
        public void SummaryInsert(SummaryPropertiesModel summaryProperties)
        {
            query = @"INSERT INTO tblSummary (DateGenerated, Title , IDClass, BoatName, GrossProfit, Salary, Operational, Maintenance, Merchandise, Tax, TotalExpenses, Commission, Handling, Unloading, NetIncome)
                     VALUES (@DateGenerated, @name ,@iDClass, @boatName, @grossProfit, @salary, @operational, @maintenance, @merchandise, @tax, @totalExpenses, @commission, @handling, @unloading, @netIncome)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) 
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@DateGenerated", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@name", summaryProperties.Title);
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@iDClass", summaryProperties.IDClass);
                    command.Parameters.AddWithValue("@boatName", summaryProperties.VesselName);
                    command.Parameters.AddWithValue("@grossProfit", summaryProperties.GrossProfit);
                    command.Parameters.AddWithValue("@salary", summaryProperties.Salary);
                    command.Parameters.AddWithValue("@operational", summaryProperties.Operational);
                    command.Parameters.AddWithValue("@maintenance", summaryProperties.Maintenance);
                    command.Parameters.AddWithValue("@merchandise", summaryProperties.Merchandise);
                    command.Parameters.AddWithValue("@tax", summaryProperties.Tax);
                    command.Parameters.AddWithValue("@totalExpenses", summaryProperties.TotalExpenses);
                    command.Parameters.AddWithValue("@commission", summaryProperties.Commission);
                    command.Parameters.AddWithValue("@handling", summaryProperties.Handling);
                    command.Parameters.AddWithValue("@unloading", summaryProperties.Unloading);
                    command.Parameters.AddWithValue("@netIncome", summaryProperties.NetIncome);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable SummaryRead()
        {
            query = @"SELECT Title, IDClass, DateGenerated FROM tblSummary";
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
