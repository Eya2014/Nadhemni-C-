
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using Nadhemni;
using System.Net;

static class Program
    {
   
   
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    [STAThread]

        static void Main()
        {
        //Conection with DataBase
       
       // MessageBox.Show("Getting Connection ...");
        SqlConnection conn = DButilis.GetDBConnection();

        try
        {
           // MessageBox.Show("Openning Connection ...");
            conn.Open();
            //MessageBox.Show("Connection successful!");


        }
        catch (Exception e)
        {
            MessageBox.Show("Error: " + e.Message);
        }

        Console.Read();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new sign_in());
        }
    }

