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
    class TaxCommissionConnector : DatabaseLocation
    {
        private string query;

        public bool InsertTaxCom(TaxPropertiesModel taxProperties)
        {
            bool ifSuccess = false;
            query = @"INSERT INTO tblTaxCommission(IDClass, Vendor, Date, Commission, KindofFish, NoofTub, NoofKilo, UnitKiloPrice, UnitTubPrice, TotalPrice, TotalCommission)
                                            VALUES(@idclass, @vendor, @date, @commission, @variety, @bucket, @kilo, @Ukilo, @UBucket, @TPrice, @TComm)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@date", taxProperties.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@vendor", taxProperties.Vendor);
                    command.Parameters.AddWithValue("@commission", taxProperties.Commission);
                    command.Parameters.AddWithValue("@variety", taxProperties.Variety);
                    command.Parameters.AddWithValue("@bucket", taxProperties.NoBucket);
                    command.Parameters.AddWithValue("@kilo", taxProperties.NoKilo);
                    command.Parameters.AddWithValue("@Ukilo", taxProperties.PriceKilo);
                    command.Parameters.AddWithValue("@UBucket", taxProperties.PriceBucket);
                    command.Parameters.AddWithValue("@TPrice", taxProperties.TotalPrice);
                    command.Parameters.AddWithValue("@TComm", taxProperties.TotalCommission);
                    if (ifSuccess = Convert.ToBoolean(command.ExecuteNonQuery()))
                    {
                        InsertUpdateTaxComm(taxProperties);
                    }
                    connection.Close();
                }
            }
            return ifSuccess;
        }

        public DataTable ReadTaxCom(string IDClass)
        {
            query = "SELECT No, IDClass, Vendor, Date, Commission, KindofFish, NoofTub, NoofKilo, UnitKiloPrice, UnitTubPrice, TotalPrice, TotalCommission FROM tblTaxCommission WHERE IDClass = @idclass";
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

        public bool DeleteTaxCom(TaxPropertiesModel taxProperties)
        {
            bool ifSuccess = false;
            query = "DELETE FROM tblTaxCommission WHERE IDClass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@no", taxProperties.No);
                    if (ifSuccess = Convert.ToBoolean(command.ExecuteNonQuery()))
                    {
                        UpdateDeleteTaxCommData(taxProperties);
                    }
                    connection.Close();
                }
            }
            return ifSuccess;
        }

        public bool UpdateTaxCom(TaxPropertiesModel taxProperties)
        {
            bool ifSuccess = false;
            query = "UPDATE tblTaxCommission SET Vendor = @vendor, Date = @date, Commission = @commission, KindofFish = @variety, NoofTub = @bucket, NoofKilo = @kilo, UnitKiloPrice = @Ukilo, UnitTubPrice = @UBucket, TotalPrice = @TPrice, TotalCommission = @TComm WHERE IDClass = @idclass AND No = @no";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@no", taxProperties.No);
                    command.Parameters.AddWithValue("@date", taxProperties.Date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@vendor", taxProperties.Vendor);
                    command.Parameters.AddWithValue("@commission", taxProperties.Commission);
                    command.Parameters.AddWithValue("@variety", taxProperties.Variety);
                    command.Parameters.AddWithValue("@bucket", taxProperties.NoBucket);
                    command.Parameters.AddWithValue("@kilo", taxProperties.NoKilo);
                    command.Parameters.AddWithValue("@Ukilo", taxProperties.PriceKilo);
                    command.Parameters.AddWithValue("@UBucket", taxProperties.PriceBucket);
                    command.Parameters.AddWithValue("@TPrice", taxProperties.TotalPrice);
                    command.Parameters.AddWithValue("@TComm", taxProperties.TotalCommission);
                    ifSuccess = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return ifSuccess;
        }

        public bool SearchDuplicate(TaxPropertiesModel taxProperties)
        {
            bool ifFound = false;
            query = @"SELECT IIF(COUNT(Vendor)> 0, 1, 0) FROM tblTaxCommission 
                    WHERE IDClass = @idclass AND Vendor = @vendor AND UnitKiloPrice = @UKilo AND UnitTubPrice = @UBucket AND
                    Commission = @commision AND KindofFish = @variety
                    ";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@vendor", taxProperties.Vendor);
                    command.Parameters.AddWithValue("@UKilo", taxProperties.PriceKilo);
                    command.Parameters.AddWithValue("@UBucket", taxProperties.PriceBucket);
                    command.Parameters.AddWithValue("@commision", taxProperties.Commission);
                    command.Parameters.AddWithValue("@variety", taxProperties.Variety);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ifFound = reader.GetBoolean(0);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            return ifFound;
        }

        public bool UpdateDuplicate(TaxPropertiesModel taxProperties)
        {
            bool ifSuccess = false;
            query = @"UPDATE tblTaxCommission SET
                     NoofTub = (SELECT NoofTub FROM tblTaxCommission WHERE IDClass = @idclass AND Vendor = @vendor AND KindofFish = @variety) + @bucket, 
                     NoofKilo = (SELECT NoofKilo FROM tblTaxCommission WHERE IDClass = @idclass  AND Vendor = @vendor AND KindofFish = @variety) + @kilo,
                     TotalPrice = (SELECT TotalPrice FROM tblTaxCommission WHERE IDClass = @idclass  AND Vendor = @vendor AND KindofFish = @variety) + @TPrice, 
                     TotalCommission = (SELECT TotalCommission FROM tblTaxCommission WHERE IDClass = @idclass  AND Vendor = @vendor AND KindofFish = @variety) + @TComm
                     WHERE IDClass = @idclass AND Vendor = @vendor AND UnitKiloPrice = @UKilo AND UnitTubPrice = @UBucket AND
                     Commission = @commision AND KindofFish = @variety
                     ";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@vendor", taxProperties.Vendor);
                    command.Parameters.AddWithValue("@UKilo", taxProperties.PriceKilo);
                    command.Parameters.AddWithValue("@UBucket", taxProperties.PriceBucket);
                    command.Parameters.AddWithValue("@commision", taxProperties.Commission);
                    command.Parameters.AddWithValue("@variety", taxProperties.Variety);
                    command.Parameters.AddWithValue("@bucket", taxProperties.NoBucket);
                    command.Parameters.AddWithValue("@kilo", taxProperties.NoKilo);
                    command.Parameters.AddWithValue("@TPrice", taxProperties.TotalPrice);
                    command.Parameters.AddWithValue("@TComm", taxProperties.TotalCommission);
                    ifSuccess = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return ifSuccess;
        }

        public void UpdateEditDataComm(TaxPropertiesModel taxProperties)
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
                    command.Parameters.AddWithValue("@Nbucket", taxProperties.NoBucket);
                    command.Parameters.AddWithValue("@Nkilo", taxProperties.NoKilo);
                    command.Parameters.AddWithValue("@Cbucket", taxProperties.CBucket);
                    command.Parameters.AddWithValue("@Ckilo", taxProperties.CKilo);
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@variety", taxProperties.Variety);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void UpdateDeleteTaxCommData(TaxPropertiesModel taxProperties)
        {
            query = @"UPDATE tblFishImportRecord SET
                    NoofTubs = (NoofTubs + @bucket),
                    NoofKilos = (NoofKilos + @kilo)
                    WHERE IDClass = @idclass AND KindofFish = @variety
            ";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@bucket", taxProperties.NoBucket);
                    command.Parameters.AddWithValue("@kilo", taxProperties.NoKilo);
                    command.Parameters.AddWithValue("@variety", taxProperties.Variety);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public bool InsertUpdateTaxComm(TaxPropertiesModel taxProperties)
        {
            bool ifSuccess = false;
            query = @"UPDATE tblFishImportRecord SET
                    NoofTubs = NoofTubs - @bucket,
                    NoofKilos = NoofKilos - @kilo
                    WHERE IDClass = @idclass AND KindofFish = @variety
                    ";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", taxProperties.IDClass);
                    command.Parameters.AddWithValue("@bucket", taxProperties.NoBucket);
                    command.Parameters.AddWithValue("@kilo", taxProperties.NoKilo);
                    command.Parameters.AddWithValue("@variety", taxProperties.Variety);
                    ifSuccess = Convert.ToBoolean(command.ExecuteNonQuery());
                    connection.Close();
                }
            }
            return ifSuccess;
        }
    }
}
