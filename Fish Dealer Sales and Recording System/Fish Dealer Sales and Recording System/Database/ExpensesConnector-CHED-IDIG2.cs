using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ExpensesConnector : DatabaseLocation
    {
        private string query;

        public void InsertExpenses(ExpensesPropertiesModel expensesProperties)
        {
            query = @"INSERT INTO tblExpensesRecord (IDClass, Category, Items, Price) 
                     VALUES (@idclass, @category, @item, @price)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", expensesProperties.IDClass);
                    command.Parameters.AddWithValue("@category", expensesProperties.Category);
                    command.Parameters.AddWithValue("@item", expensesProperties.Item);
                    command.Parameters.AddWithValue("@price", expensesProperties.Price);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable ReadExpeses(string IDClass)
        {
            query = $@"SELECT * FROM tblExpensesRecord WHERE IDClass = '{IDClass}'";
            using (DataTable table = new DataTable())
            {
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
            
        }

        public void DeleteExpenses(ExpensesPropertiesModel expensesProperties)
        {
            query = $@"DELETE FROM tblExpensesRecord WHERE IDClass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", expensesProperties.IDClass);
                    command.Parameters.AddWithValue("@no", expensesProperties.No);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateExpenses(ExpensesPropertiesModel expensesProperties)
        {
            query = $@"UPDATE tblExpensesRecord SET Category = @category, Items = @item, Price = @price
                      WHERE IDClass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@category", expensesProperties.Category);
                    command.Parameters.AddWithValue("@item", expensesProperties.Item);
                    command.Parameters.AddWithValue("@price", expensesProperties.Price);
                    command.Parameters.AddWithValue("@idclass", expensesProperties.IDClass);
                    command.Parameters.AddWithValue("@no", expensesProperties.No);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
