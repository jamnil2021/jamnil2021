using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class DataGridToDBConnector : DatabaseLocation
    {
        private string query;

        public void ExpensesDB(List<ExpensesToDBPropertiesModel> expensesToDBs)
        {
            query = "INSERT INTO CategoryExpenses(Category, ItemName) VALUES(@category, @item)";
            try
            {
                int countError = 0;
                foreach (var data in expensesToDBs)
                {
                    try
                    {
                        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                        {
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@category", data.ItemCategory);
                                command.Parameters.AddWithValue("@item", data.ItemName);
                                command.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }
                    catch(SQLiteException)
                    {
                        countError++;
                    }
                }
                if (countError != expensesToDBs.Count)
                {
                    MessageBox.Show("Successfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unsuccessfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VarietyDB(List<string> variety)
        {
            query = "INSERT INTO VarietySpecies(VarietyofFish) VALUES (@variety)";
            try
            {
                int countError = 0;
                foreach (string var in variety)
                {
                    try
                    {
                        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                        {
                            using (SQLiteCommand command = new SQLiteCommand(query, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@variety", var);
                                command.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }
                    catch(SQLiteException)
                    {
                        countError++;
                    }
                }
                if (countError != variety.Count)
                {
                    MessageBox.Show("Successfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unsuccessfully Updated!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message,"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
