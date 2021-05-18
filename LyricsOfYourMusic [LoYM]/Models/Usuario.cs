using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsOfYourMusic__LoYM_.Models
{
    public class Usuario
    {
        public string User { set; get; }
        public string Contraseña { set; get; }
        public int ID_Usuario { set; get; }
        public Consultas consultar = new Consultas();

        public bool login() {
            if (consultar.login(this.User, this.Contraseña)){
                consultar.statusActive(this.User, this.Contraseña);
                return true;
            }
            else
                return false; 
        }
        public bool registro() { 
            if(consultar.registroUsuario(this.User, this.Contraseña))
                return true;
            else
                return false; 
        }
        public bool validar()
        {
            if (consultar.existeUsuario(this.User))
                return true;
            else
                return false;
        }
        public bool statusReset() {
            consultar.statusReset();
            return true;
        }
    }
}