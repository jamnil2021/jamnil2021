using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ExpensesConnector : DatabaseLocation
    {
        private string query;
        private ItemReaderConnector readerConnector = new ItemReaderConnector();
        public bool InsertExpenses(ExpensesPropertiesModel expensesProperties)
        {
            bool ifSuccess = false;
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
                    ifSuccess = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return ifSuccess;
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
        public bool checkerExpenses(ExpensesPropertiesModel expensesProperties)
        {
            bool checker = false;
            query = "SELECT IIF(COUNT(Items) > 0, 1, 0) FROM tblExpensesRecord WHERE Category = @category AND Items = @item AND IDClass = @idclass";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", expensesProperties.IDClass);
                    command.Parameters.AddWithValue("@category", expensesProperties.Category);
                    command.Parameters.AddWithValue("@item", expensesProperties.Item);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt16(0) == 1)
                            {
                                checker = true;
                            }
                        }
                    }
                    connection.Close();
                }
            }
            return checker;
        }

        public bool UpdateDuplication(ExpensesPropertiesModel expensesProperties)
        {
            bool success = false;
            query = @"UPDATE tblExpensesRecord SET
                    Price = (SELECT Price FROM tblExpensesRecord WHERE IDClass = @idclass AND Category = @category AND Items = @item) + @price
                    WHERE IDClass = @idclass AND Category = @category AND Items = @item";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", expensesProperties.IDClass);
                    command.Parameters.AddWithValue("@price", expensesProperties.Price);
                    command.Parameters.AddWithValue("@category", expensesProperties.Category);
                    command.Parameters.AddWithValue("@item", expensesProperties.Item);
                    success = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return success;
        }
        public void InsertCategory(ExpensesPropertiesModel expensesProperties)
        {
            query = "INSERT INTO CategoryExpenses(Category, ItemName) VALUES (@category, @item)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@category", expensesProperties.Category);
                    command.Parameters.AddWithValue("@item", expensesProperties.Item);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public bool SearchDuplicationCategory(ExpensesPropertiesModel expensesProperties)
        {
            query = "SELECT IIF(COUNT(ItemName) > 0, 1, 0) FROM CategoryExpenses WHERE Category = @category AND ItemName = @item";
            bool ifFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@category", expensesProperties.Category);
                    command.Parameters.AddWithValue("@item", expensesProperties.Item);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ifFound = reader.GetBoolean(0);
                        }
                    }
                    connection.Close();
                }
            }
            return ifFound;   
        }
    }
}
