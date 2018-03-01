using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
namespace VirtualTest.Data
{
    public class DBHelper
    {
        public static void EjecutarIUD(string query)
        {
            string conectionstring = @"Data Source=localhost; Database=test; User ID=root; Password=''";
            using (MySqlConnection miConn = new MySqlConnection(conectionstring))
            {
                miConn.Open();
                MySqlCommand miCommand = new MySqlCommand(query, miConn);
                miCommand.ExecuteNonQuery();
                miConn.Close(); //Nos aseguramos de cerrar la conexion
            }
        }
        
        public static DataTable EjecutarSelect(string select)
        {
            DataTable dt = new DataTable();
            string conectionstring = @"Data Source=localhost; Database=test; User ID=root; Password=''";
            using (MySqlConnection miConn = new MySqlConnection(conectionstring))
            {
                miConn.Open();
                MySqlCommand miCommand = new MySqlCommand(select, miConn);
                MySqlDataAdapter da = new MySqlDataAdapter(miCommand);
                da.Fill(dt);
                miConn.Close(); //Nos aseguramos de cerrar la conexion
            }
            return dt;
        }

    }
}