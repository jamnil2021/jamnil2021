using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class CrewSalaryConnector : DatabaseLocation
    {
        private string query;

        public void InsertCrew(AddCrewPropertiesModel addCrewProperties)
        {
            query = @"INSERT INTO tblCrewRecord(IDClass, CrewName, Position, Salary) 
                     VALUES (@idclass, @crewname, @position, @salary)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", addCrewProperties.IDClass);
                    command.Parameters.AddWithValue("@crewname", addCrewProperties.CrewName);
                    command.Parameters.AddWithValue("@position", addCrewProperties.Position);
                    command.Parameters.AddWithValue("@salary", addCrewProperties.Salary);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateCrew(AddCrewPropertiesModel addCrewProperties)
        {
            query = @"UPDATE tblCrewRecord SET IDClass = @idclass, CrewName = @crewname, Position = @position, Salary = @salary
                      WHERE IDclass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@no", addCrewProperties.No);
                    command.Parameters.AddWithValue("@idclass", addCrewProperties.IDClass);
                    command.Parameters.AddWithValue("@crewname", addCrewProperties.CrewName);
                    command.Parameters.AddWithValue("@position", addCrewProperties.CrewName);
                    command.Parameters.AddWithValue("@salary", addCrewProperties.Salary);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable ReadCrew(string IDClass)
        {
            query = @"SELECT * FROM tblCrewRecord WHERE IDClass = @idclass ";
            using (DataTable table = new DataTable())
            {
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
                            connection.Close();
                        }
                    }
                }
                return table;
            }
        }

        public void DeleteCrew(AddCrewPropertiesModel addCrewProperties)
        {
            query = @"DELETE FROM tblCrewRecord WHERE IDClass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) 
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", addCrewProperties.IDClass);
                    command.Parameters.AddWithValue("@no", addCrewProperties.No);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public bool SearchDuplicationCrew(AddCrewPropertiesModel crewProperties)
        {
            bool ifExist = false;
            query = "SELECT IIF(COUNT(CrewName) > 0, 1, 0) FROM tblCrewRecord WHERE IDClass = @idclass AND CrewName = @crewname AND Position = @position";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", crewProperties.IDClass);
                    command.Parameters.AddWithValue("@crewname", crewProperties.CrewName);
                    command.Parameters.AddWithValue("@position", crewProperties.Position);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ifExist = reader.GetBoolean(0);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            return ifExist;
        }
        public bool UpdateDuplicateSalary(AddCrewPropertiesModel crewProperties)
        {
            bool ifSuccess = false;
            query = "UPDATE tblCrewRecord SET Salary = (Salary + @salary) WHERE IDClass = @idclass AND CrewName = @crewname AND Position = @position";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", crewProperties.IDClass);
                    command.Parameters.AddWithValue("@crewname", crewProperties.CrewName);
                    command.Parameters.AddWithValue("@salary", crewProperties.Salary);
                    command.Parameters.AddWithValue("@position", crewProperties.Position);
                    ifSuccess = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return ifSuccess;
        }
    }
}
