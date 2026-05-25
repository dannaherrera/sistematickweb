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
using System.Linq;

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


        // GET: Login
        public ActionResult Index()
        {
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

                ConexionBD newconexionBD = new ConexionBD();
                


                try
                {
                    using (SqlConnection conexion = newconexionBD.ObtenerConexion())
                    {

                        conexion.Open();

                        MensajeAlerta mensajeLogin = new MensajeAlerta();

                        ///TempData["AlertaMensaje"]="¡Hola! Este es un mensaje directo en la pantalla del navegador.";
                        TempData["AlertaLogin"] = MensajeAlerta.LoginCorrecto("¡Datos guardados correctamente desde el controlador!");

                        bool esValido = SistemaTickets.Models.Clases.ConexionBD.Validar(username, password); 

                        if (username == null || password == null)
                        {
                            System.Diagnostics.Debug.WriteLine("Por favor, llene todos los campos");
                            Response.Redirect("Index");

                        }
                        else if (esValido) 
                        {

                            int rol;
    
                            System.Diagnostics.Debug.WriteLine("¡Inicio de sesión exitoso!");
                            TempData["AlertaLogin"] = MensajeAlerta.LoginCorrecto("¡Bienvenido al sistema!");
                            System.Diagnostics.Debug.WriteLine("La VALIDACION fue exitosa!!!");
                            return Json(new
                            {
                                success = true,
                                message = "Inicio de sesión correcto.",
                                username = username,
                                rol = 1
                            });

                    }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Credenciales incorrectas.");
                            TempData["Alerta"] = "Usuario o contraseña incorrectos.";
                            return Json(new { success = false, message = "Usuario o contraseña incorrectos." });
                            ///return RedirectToAction("Index");
                        }

                        return RedirectToAction("/Menu");
                        ///return RedirectToAction("/Menu");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error en la conexion a la BD" + ex.Message);
                    TempData["MensajeError"] = "Error al conectar: " + ex.Message;
                    TempData["Alerta"] = "Error en la conexion";
                    return Json(new { success = false, message = "Ocurrió un error en el servidor: " + ex.Message });
                    ///return RedirectToAction("/Index");

                    ///return RedirectToAction("Index");
                }
            }

            [HttpPost]
        public JsonResult LoginCorrecto(string mensaje)
        {
            System.Diagnostics.Debug.WriteLine("Esta por mandar el mensaje!!!");

            string respuesta = "El servidor procesó con éxito: " + mensaje;

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        // GET: Login/Menu
        public ActionResult Menu()
        {
            return View();
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
    }
}
