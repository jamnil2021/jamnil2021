﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Fish_Dealer_Sales_and_Recording_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard());
            //Thread thread;
            //if (Properties.Settings.Default.Username == "")
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new Login());
            //}
            //else
            //{
            //    thread = new Thread(Dashboard);
            //    thread.SetApartmentState(ApartmentState.STA);
            //    thread.Start();
            //    new Login().Close();
            //}

        }
        public static void Dashboard(object obj)
        {
            Application.Run(new Dashboard());
        }
    }
}