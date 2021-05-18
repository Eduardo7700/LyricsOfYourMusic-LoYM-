using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace LyricsOfYourMusic__LoYM_.Models
{
    public class Conexion
    {
        MySqlConnection conexion = new MySqlConnection();

        public Conexion() {
            try
            {
                conexion.ConnectionString = "Server=localhost;User=root;Database=LoYM";
                conexion.Open();
            }
            catch (Exception) { }
        }
        public MySqlConnection getConexion() {
            return conexion;               
        }
        public bool closeConexion() {
            try
            {
                conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}