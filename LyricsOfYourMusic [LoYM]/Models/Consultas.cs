using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace LyricsOfYourMusic__LoYM_.Models
{
    public class Consultas
    {
        public Conexion con = new Conexion();
        MySqlCommand comando = new MySqlCommand();
        MySqlDataReader Reader; 

        public bool login(String User, String Pass){
            try{
                comando = new MySqlCommand("select ID_usuario from users where user = '" + User + "' and pass = '" + Pass + "'");
                MySqlDataAdapter adaptado = new MySqlDataAdapter();
                comando.Connection = con.getConexion();
                adaptado.SelectCommand = comando;
                DataTable datos = new DataTable();
                adaptado.Fill(datos);
                datos.AcceptChanges();
                int filas = datos.Rows.Count;
                return (filas > 0);
            }catch (Exception){
                return false;
            }
        }
        public bool statusActive(String User, String Pass){
            try{
                string cadena = "update users set status=1 where user='" + User + "' and pass='" + Pass + "'";
                comando.CommandText = cadena;
                comando.Connection = con.getConexion();
                comando.ExecuteReader();
                return true;
            }catch (Exception){
                return false;
            }
        }
        public bool statusReset(){
            try{
                string cadena = "update users set status=0";
                comando.CommandText = cadena;
                comando.Connection = con.getConexion();
                comando.ExecuteReader();
                return true;
            }catch (Exception){
                return false;
            }
        }
        public bool registroUsuario(String User, String Pass){
            try
            {
                string cadena = "insert into users values(null,'" + User + "','" + Pass + "', 0)";
                comando.CommandText = cadena;
                comando.Connection = con.getConexion();
                comando.ExecuteReader();
                return true;
            }catch (Exception){
                return false;
            }
        }
        public bool existeUsuario(String User) {
            try
            {
                comando = new MySqlCommand("select ID_usuario from users where user = '" + User + "'");
                MySqlDataAdapter adaptado = new MySqlDataAdapter();
                comando.Connection = con.getConexion();
                adaptado.SelectCommand = comando;
                DataTable datos = new DataTable();
                adaptado.Fill(datos);
                datos.AcceptChanges();
                int filas = datos.Rows.Count;
                return (filas > 0);
            }catch (Exception){
                return false;
            }
        }
        public int getIDUser() {
            int id = 0;
            try
            {
                con.closeConexion();
                con = new Conexion();
                comando.CommandText = "select ID_usuario from users where status = 1";
                comando.Connection = con.getConexion();
                Reader = comando.ExecuteReader();
                while (Reader.Read())
                    id = Int32.Parse(Reader["ID_usuario"].ToString());
            }
            catch (Exception ex)
            {
                id = 0;
            }
            return id;
        }
        //Consultas Canciones
        
        public List<String> getCanciones(){
            List<String> lista = new List<String>();
            try{
                string id = "" + getIDUser();
                comando.CommandText = "select nombre from canciones where ID_usuario="+id;
                con.closeConexion();
                con = new Conexion();
                comando.Connection = con.getConexion();
                Reader = comando.ExecuteReader();
                while (Reader.Read()){
                        lista.Add(Reader["nombre"].ToString());                    
                }
                if (lista.Count == 0) {
                    lista.Add("No hay Elementos para mostrar");
                }
            }catch (Exception ex){
                lista.Add("Error: " + ex);
            }
            return lista;
        }
        public string getArtista(String nombre){
            string artista = "Desconocido";
            try{
                string id = "" + getIDUser();
                comando.CommandText = "select artista from canciones where nombre = '" + nombre + "' and ID_usuario="+id;
                con.closeConexion();
                con = new Conexion();
                comando.Connection = con.getConexion();
                Reader = comando.ExecuteReader();
                while (Reader.Read())
                    artista = Reader["artista"].ToString();                
            }
            catch (Exception ex)
            {
                artista = "Error: " + ex;
            }
            return artista;
        }
        public String getLetra(string nombre){
            string artista = "Desconocido";
                    try{
                        string id = "" + getIDUser();                        
                        comando.CommandText = "select letra from canciones where nombre = '" + nombre + "' and ID_usuario="+id;
                        con.closeConexion();
                        con = new Conexion();
                        comando.Connection = con.getConexion();
                        Reader = comando.ExecuteReader();
                        while (Reader.Read())
                            artista = Reader["letra"].ToString();                
                    }
                    catch (Exception ex)
                    {
                        artista = "Error: " + ex;
                    }
                    return artista;
        }
        public bool eliminar(string cancion) {
            try{
                string id = "" + getIDUser();
                comando.CommandText = "delete from canciones where nombre='" + cancion + "' and ID_usuario="+id;
                con.closeConexion();
                con = new Conexion();
                comando.Connection = con.getConexion();
                comando.ExecuteReader();
                return true;
            }
            catch (Exception){
                return false;
            }        
        }
        public bool existeCancion(string cancion)
        {
            string cm = "";
            try
            {
                string id = "" + getIDUser();
                cm = "select ID_cancion from canciones where nombre = '" + cancion + "' and ID_usuario=" + id;
                comando = new MySqlCommand(cm);
                MySqlDataAdapter adaptado = new MySqlDataAdapter();
                con.closeConexion();
                con = new Conexion();
                comando.Connection = con.getConexion();
                adaptado.SelectCommand = comando;
                DataTable datos = new DataTable();
                adaptado.Fill(datos);
                datos.AcceptChanges();
                int filas = datos.Rows.Count;
                return (filas > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool agregarCancion(string nombre, string artista, String Letra) {
            try
            {
                if(!existeCancion(nombre)){
                    string id = "" + getIDUser();
                    string cadena = "insert into canciones values(null,'" + nombre + "','" + artista + "','"+Letra+"', "+id+")";
                    comando.CommandText = cadena;
                    con.closeConexion();
                    con = new Conexion();
                    comando.Connection = con.getConexion();
                    comando.ExecuteReader();
                    return true;
                }else
                   return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool modificarNombre(string cancion, string ncancion)
        {
            string err = "";
            try
            {
                string id = "" + getIDUser();
                err = "update canciones set nombre='" + ncancion + "' where nombre='" + cancion + "' and ID_usuario=" + id;
                comando.CommandText = err;
                con.closeConexion();
                con = new Conexion();
                comando.Connection = con.getConexion();
                comando.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool modificarArtista(string cancion, string artista)
        {
            try
            {
                string id = "" + getIDUser();
                comando.CommandText = "update canciones set artista='" + artista + "' where nombre='" + cancion + "' and ID_usuario=" + id;
                con.closeConexion();
                con = new Conexion();
                comando.Connection = con.getConexion();
                comando.ExecuteReader();               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool modificarLetra(string cancion, String Letra)
        {
            try
            {
                string id = "" + getIDUser();
                comando.CommandText = "update canciones set letra='" + Letra + "' where nombre='" + cancion + "' and ID_usuario=" + id;
                con.closeConexion();
                con = new Conexion();
                comando.Connection = con.getConexion();
                comando.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}