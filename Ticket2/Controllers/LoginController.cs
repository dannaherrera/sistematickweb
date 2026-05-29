using SistemaTickets.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticket2.Models.clases;
//using System.Linq;

namespace Ticket2.Controllers
{
    public class LoginController : Controller
    {

        public class DashboardController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            if (Session["UsuarioLogin"] != null)
            {
                return RedirectToAction("Menu", "VistasS"); 
            }

            return View();
        }


        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /*
        [HttpPost]
        public ActionResult Entrar(string username, string password)
        {
            try
            {
                // Aquí va tu lógica actual con tu modelo ConexionBD para validar el usuario
                bool usuarioValido = true; // Reemplazar con tu validación real de Base de Datos
                string rolUsuario = "Soporte"; // Reemplazar con el rol real si lo tienes

                if (usuarioValido)
                {
                    // Devolvemos un JSON indicando éxito y los datos que guardará sessionStorage
                    
                }
                else
                {
                    // Devolvemos JSON indicando el fallo de credenciales
                    return Json(new { success = false, message = "Usuario o contraseña incorrectos." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error en el servidor: " + ex.Message });
            }
        }*/


        [HttpPost]
        public ActionResult Entrar(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData["Alerta"] = "Por favor, llene todos los campos.";
                return RedirectToAction("Index");
            }

            ConexionBD newconexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = newconexionBD.ObtenerConexion())
                {
                    conexion.Open();
                    bool esValido = ConexionBD.Validar(username, password);

                    if (esValido)
                    {
                        Session["UsuarioLogin"] = username;

                        return RedirectToAction("Menu", "VistasS");
                    }
                    else
                    {
                        TempData["Alerta"] = "Usuario o contraseña incorrectos.";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                TempData["Alerta"] = "Ocurrió un error en el servidor.";
                return RedirectToAction("Index");
            }
        }


        public ActionResult CerrarSesion()
        {
            Session["UsuarioLogin"] = null;
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult LoginCorrecto(string mensaje)
        {
            System.Diagnostics.Debug.WriteLine("Esta por mandar el mensaje!!!");

            string respuesta = "El servidor procesó con éxito: " + mensaje;

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }




        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Onclick()
        {
            return RedirectToAction("Menu");
        }
    }
}
