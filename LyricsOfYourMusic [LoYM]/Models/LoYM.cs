using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsOfYourMusic__LoYM_.Models
{
    public class LoYM
    {
        public string Cancion { set; get; }
        public string Artista { set; get; }
        public String Letra { set; get; }
        public string err { set; get; }
        public Consultas consultar = new Consultas();

        public List<String> getCanciones(){
            return consultar.getCanciones();
        }
        public String getLetra(string nombre) {
            return consultar.getLetra(nombre);
        }
        public string getArtista(string nombre) {
            return consultar.getArtista(nombre);
        }
        public bool eliminar(string cancion) {
            return consultar.eliminar(cancion);        
        }
        public bool agregar() {
            return consultar.agregarCancion(this.Cancion, this.Artista, this.Letra);
        }
        public bool modificar(string cancion) {
            if (this.Cancion != null)
            {
                if (!consultar.existeCancion(this.Cancion))
                {
                    if (consultar.modificarNombre(cancion, this.Cancion))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            if (this.Artista != null)
            {
                consultar.modificarArtista(cancion, this.Artista);
                return true;
            }
            if (this.Letra != null)
            {
                consultar.modificarLetra(cancion, this.Letra);
                return true;
            }
            return false;
        }
    }
}