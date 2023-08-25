using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class DataTableConnector : DatabaseLocation
    {
        private string query;
        public DataTable DataTablePrint(string IDClass)
        {
            query = @"SELECT IIF(COUNT(TotalPrice) > 0, SUM(TotalPrice), 0) AS GrossProfit, (SELECT IIF(SUM(Salary) > 0, SUM(Salary), 0) FROM tblCrewRecord WHERE IDClass = @idclass) AS TotalSalary, 
                    (SELECT IIF(COUNT(Price) > 0, SUM(Price),0) FROM tblExpensesRecord WHERE IDClass = @idclass AND Category = 'MAINTENANCE AND REPAIR') AS TotalMaintenance,
                    (SELECT IIF(COUNT(Price) > 0,SUM(Price) , 0) FROM tblExpensesRecord WHERE IDClass = @idclass AND Category = 'OPERATIONAL') AS TotalOperational,
                    (SELECT IIF(COUNT(Price) > 0,SUM(Price) , 0) FROM tblExpensesRecord WHERE IDClass = @idclass AND Category = 'MERCHANDISE') AS TotalMerchandise,
                    (SELECT IIF(COUNT(TotalCommission) > 0, SUM(TotalCommission),0) FROM tblTaxCommission WHERE IDClass = @idclass) AS Commission,
                    (SELECT IIF(COUNT(Handling) > 0, Handling, 0) FROM tblTax WHERE IDClass = @idclass) AS Handling,
                    (SELECT IIF(COUNT(Unloading) > 0, Unloading, 0) FROM tblTax WHERE IDClass = @idclass) AS Unloading, 
                    (SELECT IIF(COUNT(Tax) > 0, Tax, 0) FROM tblTax WHERE IDClass = @idclass) AS Tax,
                    (SELECT IIF(COUNT(TotalTubs) > 0, SUM(TotalTubs), 0) FROM tblFishImportRecord WHERE IDClass = @idclass) AS TotalTubs
                     FROM tblCostumerData WHERE IDClass = @idclass";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@idclass", IDClass);
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

        public DataTable CostumersData(string query)
        {
            query = String.Format(query);
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            connection.Open();
                            adapter.Fill(table);
                            connection.Close();
                        }
                    }
                }
                return table;
            }
        }
        public DataTable DataTableWeekPrint()
        {
            query = @"SELECT BoatName,
		    DATE('NOW', '+1 Days') AS Modified,
		    CastOff,
		    (SELECT IIF(COUNT(TotalPrice)>0,SUM(TotalPrice),0) FROM tblCostumerData WHERE IDClass = depRec.IDClass) AS GrossProfit,
		    (SELECT IIF(COUNT(Salary)>0,SUM(Salary),0) FROM tblCrewRecord WHERE strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalSalary,
		    (SELECT IIF(COUNT(Price)>0,SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'MAINTENANCE AND REPAIR' AND strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalMaintenance,
		    (SELECT IIF(COUNT(Price)>0,SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'OPERATIONAL' AND strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalOperational,
		    (SELECT IIF(COUNT(Price)>0,SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'MERCHANDISE' AND strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalMerchandise,
		    (SELECT IIF(COUNT(Commission)>0,SUM(Commission),0) FROM tblTaxCommission WHERE  strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Commission,
		    (SELECT IIF(COUNT(Handling)>0,Handling,0) FROM tblTax WHERE  strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Handling,
		    (SELECT IIF(COUNT(Unloading)>0,Unloading,0) FROM tblTax WHERE  strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Unloading, 
		    (SELECT IIF(COUNT(Tax)>0,Tax,0) FROM tblTax WHERE strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) * (SELECT SUM(TotalTubs) FROM tblFishImportRecord WHERE strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Tax
            FROM tblDepartureRecord AS depRec
            WHERE strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND (SELECT COUNT(KindofFish)FROM tblFishImportRecord WHERE strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) > 0
             ";

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
                            connection.Close();
                        }
                    }
                }
                return table;
            }
        }

        public DataTable DataTableMonthPrint()
        {
            query = @"SELECT BoatName,
		    DATE('NOW', '+1 Days') AS Modified,
		    CastOff,
		    (SELECT IFNULL(SUM(TotalPrice),0) FROM tblCostumerData WHERE IDClass = depRec.IDClass AND strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW'))) AS GrossProfit,
		    (SELECT IFNULL(SUM(Salary),0) FROM tblCrewRecord WHERE strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalSalary,
		    (SELECT IFNULL(SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'MAINTENANCE AND REPAIR' AND strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalMaintenance,
		    (SELECT IFNULL(SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'OPERATIONAL' AND strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalOperational,
		    (SELECT IFNULL(SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'MERCHANDISE' AND strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS TotalMerchandise,
		    (SELECT IFNULL(SUM(Commission),0) FROM tblTaxCommission WHERE strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Commission,
		    (SELECT IFNULL(Handling,0) FROM tblTax WHERE  strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Handling,
		    (SELECT IFNULL(Unloading,0) FROM tblTax WHERE  strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Unloading, 
		    (SELECT IFNULL(Tax,0) FROM tblTax WHERE strftime('%M', Date('NOW')) = strftime('%M', DATE(DATE('NOW')),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) * (SELECT SUM(TotalTubs) FROM tblFishImportRecord WHERE strftime('%W', Date('NOW')) = strftime('%W', DATE('NOW')) AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW')) AND IDClass = depRec.IDClass) AS Tax
            FROM tblDepartureRecord AS depRec
            WHERE strftime('%M', Date('NOW')) = strftime('%M', DATE('NOW'),'-1 DAY') AND strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW'))
             ";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
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

        public DataTable DataTableYearPrint()
        {
            query = @"SELECT BoatName,
		    DATE('NOW', '+1 Days') AS Modified,
		    CastOff,
		    (SELECT IFNULL(SUM(TotalPrice),0) FROM tblCostumerData WHERE IDClass = depRec.IDClass) AS GrossProfit,
		    (SELECT IFNULL(SUM(Salary),0) FROM tblCrewRecord WHERE IDClass = depRec.IDClass) AS TotalSalary,
		    (SELECT IFNULL(SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'MAINTENANCE AND REPAIR' AND IDClass = depRec.IDClass) AS TotalMaintenance,
		    (SELECT IFNULL(SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'OPERATIONAL' AND IDClass = depRec.IDClass) AS TotalOperational,
		    (SELECT IFNULL(SUM(Price),0) FROM tblExpensesRecord WHERE Category = 'MERCHANDISE' AND IDClass = depRec.IDClass) AS TotalMerchandise,
		    (SELECT IFNULL(SUM(Commission),0) FROM tblTaxCommission WHERE  IDClass = depRec.IDClass) AS Commission,
		    (SELECT IFNULL(Handling,0) FROM tblTax WHERE IDClass = depRec.IDClass) AS Handling,
		    (SELECT IFNULL(Unloading,0) FROM tblTax WHERE IDClass = depRec.IDClass) AS Unloading, 
		    (SELECT IFNULL(Tax,0) FROM tblTax WHERE IDClass = depRec.IDClass) * (SELECT SUM(TotalTubs) FROM tblFishImportRecord WHERE IDClass = depRec.IDClass) AS Tax
            FROM tblDepartureRecord AS depRec
            WHERE strftime('%Y', Date('NOW')) = strftime('%Y', DATE('NOW'))
             ";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
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
        public DataTable DataIDCLass()
        {
            query = @"SELECT DISTINCT IDClass FROM tblCostumerData WHERE strftime('%W', Date) = strftime('%W', DATE()) AND strftime('%Y', Date) = strftime('%Y', DATE())";
            using (DataTable table = new DataTable())
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
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

        public void InsertSummary(SummaryPropertiesModel summaryProperties)
        {
            query = @"INSERT INTO tblSummary 
                    (DateGenerated, Title, IDClass, BoatName, GrossProfit, Salary, Operational, Maintenance, Merchandise, Tax, TotalExpenses, Commission, Handling, Unloading, NetIncome)
                    VALUES (@DateGenerated, @Title, @IDClass, @BoatName, @GrossProfit, @Salary, @Operational, @Maintenance, @Merchandise, @Tax, @TotalExpenses, @Commission, @Handling, @Unloading, @NetIncome)";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@DateGenerated", summaryProperties.DateGenerated.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Title", summaryProperties.Title);
                    command.Parameters.AddWithValue("@IDClass", summaryProperties.IDClass);
                    command.Parameters.AddWithValue("@BoatName", summaryProperties.VesselName);
                    command.Parameters.AddWithValue("@GrossProfit", summaryProperties.GrossProfit);
                    command.Parameters.AddWithValue("@Salary", summaryProperties.Salary);
                    command.Parameters.AddWithValue("@Operational", summaryProperties.Operational);
                    command.Parameters.AddWithValue("@Maintenance", summaryProperties.Maintenance);
                    command.Parameters.AddWithValue("@Merchandise", summaryProperties.Merchandise);
                    command.Parameters.AddWithValue("@Tax", summaryProperties.Tax);
                    command.Parameters.AddWithValue("@TotalExpenses", summaryProperties.TotalExpenses);
                    command.Parameters.AddWithValue("@Commission", summaryProperties.Commission);
                    command.Parameters.AddWithValue("@Handling", summaryProperties.Handling);
                    command.Parameters.AddWithValue("@Unloading", summaryProperties.Unloading);
                    command.Parameters.AddWithValue("@NetIncome", summaryProperties.NetIncome);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public bool SearchExist()
        {
            bool Found = false;
            query = @"SELECT IIF(COUNT(DateGenerated)>0, 1, 0) FROM tblSummary WHERE DateGenerated = @DateGenerated";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@DateGenerated", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Found = reader.GetBoolean(0);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            return Found;
        }

        public DataTable ReadData()
        {
            query = @"SELECT IDClass, Title || ' ' || DateGenerated AS GeneratedDate FROM tblSummary WHERE Title != 'Dummy' LIMIT 1";
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

        public List<PrintDataPropertiesModel> PrintData(string IDClass)
        {
            List<PrintDataPropertiesModel> _list = new List<PrintDataPropertiesModel>();
            query = @"SELECT DateGenerated, BoatName, GrossProfit, Salary, Operational, Maintenance, 
            Merchandise, Tax, TotalExpenses, Commission, Handling, Unloading, NetIncome, Title FROM tblSummary WHERE IDClass = @idclass";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@idclass", IDClass);
                    command.ExecuteNonQuery();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PrintDataPropertiesModel _properties = new PrintDataPropertiesModel();
                            _properties.DateGenerated = reader.GetDateTime(0);
                            _properties.VesselName = reader.GetString(1);
                            _properties.GrossProfit = reader.GetDecimal(2);
                            _properties.Salary = reader.GetDecimal(3);
                            _properties.Operational = reader.GetDecimal(4);
                            _properties.Maintenance = reader.GetDecimal(5);
                            _properties.Merchandise = reader.GetDecimal(6);
                            _properties.Tax = reader.GetDecimal(7);
                            _properties.TotalExpenses = reader.GetDecimal(8);
                            _properties.Commission = reader.GetDecimal(9);
                            _properties.Handling = reader.GetDecimal(10);
                            _properties.Unloading = reader.GetDecimal(11);
                            _properties.NetIncome = reader.GetDecimal(12);
                            _properties.Title = reader.GetString(13);
                            _list.Add(_properties);
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            return _list;
        }
    }
}
