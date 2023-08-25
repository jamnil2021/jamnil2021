using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class ExportConnector : DatabaseLocation
    {
        private string query;
        private string CostumersName;
        public void InsertExport(ExportPropertiesModel exportProperties)
        {
            query = @"INSERT INTO tblCostumerData (IDClass, Date, Vendor, KindofFish, NoofTub, NoofKilo, UnitTubPrice, UnitKiloPrice, TotalPrice) 
                            VALUES(@idclass, @date, @vendor, @fish, @tubs, @kilo, @Tubprice, @KiloPrice, @Tprice)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@date", exportProperties.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@vendor", exportProperties.Vendor);
                    command.Parameters.AddWithValue("@fish", exportProperties.Variety);
                    command.Parameters.AddWithValue("@tubs", exportProperties.Bucket);
                    command.Parameters.AddWithValue("@kilo", exportProperties.Kilo);
                    command.Parameters.AddWithValue("@Tubprice", exportProperties.UnitBucketPrice);
                    command.Parameters.AddWithValue("@Kiloprice", exportProperties.UnitKiloPrice);
                    command.Parameters.AddWithValue("@Tprice", exportProperties.TotalPrice1);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateExport(ExportPropertiesModel exportProperties)
        {
            query = @"UPDATE tblCostumerData SET  Date = @date, Vendor = @vendor, KindofFish = @fish,NoofTub = @tubs, NoofKilo = @kilo, 
                    UnitTubPrice = @Tubprice, UnitKiloPrice = @KiloPrice, TotalPrice = @Tprice WHERE IDClass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@no", exportProperties.No);
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@date", exportProperties.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@vendor", exportProperties.Vendor);
                    command.Parameters.AddWithValue("@fish", exportProperties.Variety);
                    command.Parameters.AddWithValue("@tubs", exportProperties.Bucket);
                    command.Parameters.AddWithValue("@kilo", exportProperties.Kilo);
                    command.Parameters.AddWithValue("@Tubprice", exportProperties.UnitBucketPrice);
                    command.Parameters.AddWithValue("@Kiloprice", exportProperties.UnitKiloPrice);
                    command.Parameters.AddWithValue("@Tprice", exportProperties.TotalPrice1);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void DeleteExport(ExportPropertiesModel exportProperties)
        {
            query = @"DELETE FROM tblCostumerData WHERE IDClass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@no", exportProperties.No);
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public DataTable ReadExport(string IDClass)
        {
            
            query = $@"SELECT No ,IDClass, Date, Vendor, KindofFish, IIF(NoofTub > 0, NoofTub, 0) AS NoofTub, IIF(NoofKilo > 0, NoofKilo, 0) AS NoofKilo, IIF(UnitTubPrice > 0, UnitTubPrice, 0) AS UnitTubPrice, IIF(UnitKiloPrice > 0, UnitKiloPrice, 0) AS UnitKiloPrice, IIF(TotalPrice > 0, TotalPrice, 0) AS TotalPrice FROM tblCostumerData WHERE IDClass = '{IDClass}'";
            using (DataTable data = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(data);
                        connection.Close();
                    }
                }
                return data;
            }
        }

        public void InsertCustomersName(string CostumersName)
        {
            this.CostumersName = CostumersName.TrimStart();
            if (SearchCostumersName(CostumersName.TrimEnd()) == false)
            {
                query = "INSERT INTO CostumerName(Name) VALUES(@name)";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@name", CostumersName);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }
        public bool SearchCostumersName(string CostumersName)
        {
            bool exist = false;
            query = "SELECT IIF(COUNT(Name)>0, 1 , 0) FROM CostumerName WHERE Name = @name";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", CostumersName);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exist = reader.GetBoolean(0);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return exist;
        }

        public DataTable SelectedDataForEditing(string IDClass, string Variety)
        {
            query = "SELECT KindofFish, NoofTubs, NoofKilos FROM tblFishImportRecord WHERE IDClass = @idclass AND KindofFish = @variety";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@idclass", IDClass);
                        command.Parameters.AddWithValue("@variety", Variety);
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

        public bool SearchDuplication(ExportPropertiesModel exportProperties)
        {
            bool ifDuplicate = false;
            query = "SELECT IIF(COUNT(Vendor) > 0, 1 , 0) FROM tblCostumerData WHERE IDClass = @idclass AND KindofFish = @variety AND Vendor = @vendor AND Date = @date AND UnitTubPrice = @UTPrice AND UnitKiloPrice = @UKPrice";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@date", exportProperties.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", exportProperties.Variety);
                    command.Parameters.AddWithValue("@vendor", exportProperties.Vendor);
                    command.Parameters.AddWithValue("@UTPrice", exportProperties.UnitBucketPrice);
                    command.Parameters.AddWithValue("@UKPrice", exportProperties.UnitKiloPrice);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ifDuplicate = reader.GetBoolean(0);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            return ifDuplicate;
        }

        public void UpdateDuplication(ExportPropertiesModel exportProperties)
        {
            query = @"UPDATE tblCostumerData SET 
                    NoofTub = (SELECT NoofTub FROM tblCostumerData WHERE IDClass = @idclass AND KindofFish = @variety AND Vendor = @vendor) + @bucket,
                    NoofKilo = (SELECT NoofKilo FROM tblCostumerData WHERE IDClass = @idclass AND KindofFish = @variety AND Vendor = @vendor) + @kilo,
                    TotalPrice = (SELECT TotalPrice FROM tblCostumerData WHERE IDClass = @idclass AND KindofFish = @variety) + @tKilo
                    WHERE KindofFish = @variety AND Vendor = @vendor AND IDClass = @idclass AND UnitTubPrice = @UTPrice AND UnitKiloPrice = @UKPrice";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", exportProperties.Variety);
                    command.Parameters.AddWithValue("@bucket", exportProperties.Bucket);
                    command.Parameters.AddWithValue("@kilo", exportProperties.Kilo);
                    command.Parameters.AddWithValue("@tKilo", exportProperties.TotalPrice1);
                    command.Parameters.AddWithValue("@vendor", exportProperties.Vendor);
                    command.Parameters.AddWithValue("@idclass", exportProperties.IDClass);
                    command.Parameters.AddWithValue("@UTPrice", exportProperties.UnitBucketPrice);
                    command.Parameters.AddWithValue("@UKPrice", exportProperties.UnitKiloPrice);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
