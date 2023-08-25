using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ImportConnector : DatabaseLocation
    {
        private string query;

        public void InsertImport(ImportPropertiesModel importProperties)
        {
            query = @"INSERT INTO tblFishImportRecord(IDClass, KindofFish, TotalTubs,  NoofTubs, NoofKilos) 
                    VALUES(@idclass, @kindoffish, @TotalTubs, @nooftubs, @noofkilos)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection)) 
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", importProperties.IDClass);
                    command.Parameters.AddWithValue("@kindoffish", importProperties.ItemName);
                    command.Parameters.AddWithValue("@TotalTubs", importProperties.NoofBucket);
                    command.Parameters.AddWithValue("@nooftubs", importProperties.NoofBucket);
                    command.Parameters.AddWithValue("@noofkilos", importProperties.QuantityKilo);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable ReadImport(string IDClass)
        {
            query = $@"SELECT * FROM tblFishImportRecord WHERE IDClass = '{IDClass}'";
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

        // Delete data row in the database Table
        public void DeleteImport(ImportPropertiesModel importProperties)
        {
            query = $@"DELETE FROM tblFishImportRecord WHERE No = @no AND IDClass = @idclass";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) 
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@no", importProperties.No);
                    command.Parameters.AddWithValue("@idclass", importProperties.IDClass);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateImport(ImportPropertiesModel importProperties)
        {
            query = @"UPDATE tblFishImportRecord SET KindofFish = @kindoffish, TotalTubs = @TotalTubs, NoofTubs = @nooftubs, NoofKilos = @noofkilos 
                    WHERE No = @no AND IDClass = @idclass";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@kindoffish", importProperties.ItemName);
                    command.Parameters.AddWithValue("@TotalTubs", importProperties.NoofBucket);
                    command.Parameters.AddWithValue("@nooftubs", importProperties.NoofBucket);
                    command.Parameters.AddWithValue("@noofkilos", importProperties.QuantityKilo);
                    command.Parameters.AddWithValue("@no", importProperties.No);
                    command.Parameters.AddWithValue("@idclass", importProperties.IDClass);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        // Select all data in database and Store in DataTable
        public DataTable RetrieverData(string IDClass)
        {
            query = $@"SELECT KindofFish, NoofTubs, NoofKilos FROM tblFishImportRecord WHERE IDClass = '{IDClass}'";
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
        public void UpdateInsertData(ExportPropertiesModel exportProperties)
        {
            query = $@"UPDATE tblFishImportRecord SET NoofTubs = (NoofTubs - @bucket), NoofKilos = (NoofKilos - @kilo)
                      WHERE IDClass = @idclass AND KindofFish = @variety";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@bucket", exportProperties.Bucket);
                    command.Parameters.AddWithValue("@kilo", exportProperties.Kilo);
                    command.Parameters.AddWithValue("@bucket", exportProperties.Bucket);
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", exportProperties.Variety);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        // Return all the data when the row is deleted!
        public void UpdateDeleteData(ExportPropertiesModel exportProperties)
        {
            query = $@"UPDATE tblFishImportRecord SET NoofTubs = (NoofTubs + @bucket), NoofKilos = (NoofKilos + @kilo)
                      WHERE IDClass = @idclass AND KindofFish = @variety";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@bucket", exportProperties.Bucket);
                    command.Parameters.AddWithValue("@kilo", exportProperties.Kilo);
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", exportProperties.Variety); ;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        // Update Costumers data
        public void UpdateEditData(ExportPropertiesModel exportProperties)
        {
            query = $@"UPDATE tblFishImportRecord
                       SET NoofTubs = CASE 
                                      WHEN @Cbucket > @Nbucket THEN NoofTubs + (@Cbucket - @Nbucket)
                                      WHEN @Cbucket < @Nbucket THEN NoofTubs - (@Nbucket - @Cbucket)
                                      ELSE NoofTubs
                                      END
                         ,NoofKilos = CASE
                                      WHEN @Ckilo > @Nkilo THEN NoofKilos + (@Ckilo - @Nkilo)
                                      WHEN @Ckilo < @Nkilo THEN NoofKilos - (@Nkilo - @Ckilo)
                                      ELSE NoofKilos
                                      END
                       WHERE IDClass = @idclass AND KindofFish = @variety";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Nbucket", exportProperties.Bucket);
                    command.Parameters.AddWithValue("@Nkilo", exportProperties.Kilo);
                    command.Parameters.AddWithValue("@Cbucket", exportProperties.CBucket);
                    command.Parameters.AddWithValue("@Ckilo", exportProperties.CKilo);
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", exportProperties.Variety);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        // Import Checker Duplication
        public bool SearchDuplicate(ImportPropertiesModel importProperties)
        {
            bool result = false;
            query = "SELECT IIF(COUNT(KindofFish)>0, 1, 0) FROM tblFishImportRecord WHERE IDClass = @idclass AND KindofFish = @variety";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", importProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", importProperties.ItemName);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt16(0) > 0)
                            {
                                result = true;
                            }
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            return result;
        }

        // Duplication Update
        public bool UpdateDuplication(ImportPropertiesModel importProperties)
        {
            bool success = false;
            query = "UPDATE tblFishImportRecord SET NoofTubs = (SELECT NoofTubs FROM tblFishImportRecord WHERE IDClass = @idclass AND KindofFish = @variety) + @nooftub, NoofKilos =(SELECT NoofTubs FROM tblFishImportRecord WHERE IDClass = @idclass AND KindofFish = @variety) + @noofkilo WHERE IDClass = @idclass AND KindofFish = @variety";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@nooftub", importProperties.NoofBucket);
                    command.Parameters.AddWithValue("@noofkilo", importProperties.QuantityKilo);
                    command.Parameters.AddWithValue("@idclass", importProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", importProperties.ItemName);
                    command.ExecuteNonQuery();
                    success = true;
                    connection.Close();
                }
            }
            return success;
        }
        public bool CheckerNewSpecies(string Variety)
        {
            bool variety = false;
            query = "SELECT IIF(COUNT(VarietyofFish)>0, 1, 0) FROM VarietySpecies WHERE VarietyofFish = @variety";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@variety", Variety);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            variety = reader.GetBoolean(0);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
                return variety;
            }
        }

        public DataTable ReadTotalTubs(string IDClass)
        {
            query = "SELECT SUM(TotalTubs) AS TotalTubs  FROM tblFishImportRecord WHERE IDClass = @idclass";
            using (DataTable table = new DataTable())
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
