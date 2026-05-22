using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Services.Description;
using System.Web.UI;

namespace Ticket2.Models.clases
{
    public class MensajeAlerta
    {


        public static string LoginCorrecto(string mensaje)
        {
            System.Diagnostics.Debug.WriteLine("Esta por mandar el mensaje!!!");
            string mensaje1 = mensaje;
            return mensaje1;

        }    
        /*
        public static Mensaje LoginCorrecto(string usuario)
        {
            return Exito("Bienvenido " + usuario);
        }

        public static Mensaje LoginIncorrecto()
        {
            return Error("Usuario o contraseña incorrectos.");
        }

        public static Mensaje CredencialesVacias()
        {
            return Advertencia("Debes ingresar usuario y contraseña.");
        }

        public static Mensaje ErrorConexion()
        {
            return Error("Ocurrió un error al conectar con la base de datos.");
        }*/

    }

}