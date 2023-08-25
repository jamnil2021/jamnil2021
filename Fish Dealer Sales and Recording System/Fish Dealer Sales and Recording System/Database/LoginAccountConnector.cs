using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Dealer_Sales_and_Recording_System
{
    public class LoginAccountConnector : DatabaseLocation
    {
        private string query;

        private Thread threading;

        private Form dashboard;

        public void AccountDataDelete()
        {

            throw new NotImplementedException();
        }

        public void AccountDataInsert(string Username, string Password, string Status)
        {
            query = @"INSERT INTO tblUserAccount (Username, Password, Status)
                    VALUES (@user, @pass, @status)";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@user", Username);
                        command.Parameters.AddWithValue("@pass", Password);
                        command.Parameters.AddWithValue("@status", Status);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataSet AccountDataRead()
        {
            throw new NotImplementedException();
        }

        public void AccountDataUpdate()
        {
            throw new NotImplementedException();
        }

        public void AccountLogin(TextBox user, TextBox pass, Form dashboard, Form login)
        {
            query = "SELECT * FROM tblUserAccount WHERE Username = @user AND  Password = @pass";
            this.dashboard = dashboard;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            connection.Open();
                            command.Parameters.AddWithValue("@user", user.Text.Trim());
                            command.Parameters.AddWithValue("@pass", pass.Text.Trim());

                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                Properties.Settings.Default.Username = user.Text;
                                Properties.Settings.Default.Save();
                                login.Close();
                                threading = new Thread(Dashboard);
                                threading.SetApartmentState(ApartmentState.STA);
                                threading.Start();
                            }
                            else
                            {
                                connection.Close();
                                MessageBox.Show("Check Your Username and Password!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                user.Text = "";
                                pass.Text = "";
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Dashboard()
        {
            Application.Run(dashboard);
        }
    }
}
