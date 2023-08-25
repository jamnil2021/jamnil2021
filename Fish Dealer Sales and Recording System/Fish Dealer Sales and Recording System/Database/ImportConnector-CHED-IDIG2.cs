using System.Data;
using System.Data.SQLite;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ImportConnector : DatabaseLocation
    {
        private string query;

        public void InsertImport(ImportPropertiesModel importProperties)
        {
            query = @"INSERT INTO tblFishImportRecord(IDClass, KindofFish, NoofTubs, NoofKilos) 
                    VALUES(@idclass, @kindoffish, @nooftubs, @noofkilos)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection)) 
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", importProperties.IDClass);
                    command.Parameters.AddWithValue("@kindoffish", importProperties.ItemName);
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
            query = @"UPDATE tblFishImportRecord SET KindofFish = @kindoffish, NoofTubs = @nooftubs, NoofKilos = @noofkilos 
                    WHERE No = @no AND IDClass = @idclass";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@kindoffish", importProperties.ItemName);
                    command.Parameters.AddWithValue("@nooftubs", importProperties.NoofBucket);
                    command.Parameters.AddWithValue("@noofkilos", importProperties.QuantityKilo);
                    command.Parameters.AddWithValue("@no", importProperties.No);
                    command.Parameters.AddWithValue("@idclass", importProperties.IDClass);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

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
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", exportProperties.Variety);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
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
    }
}
