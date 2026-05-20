using SistemaTickets.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticket2.Controllers
{
    public class LoginController : Controller
    {
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

        [HttpPost]
        public ActionResult Entrar(string username, string password)
        {
            ConexionBD newconexionBD = new ConexionBD();

            try
            {
                using (SqlConnection conexion = newconexionBD.ObtenerConexion())
                {

                    conexion.Open();

                    System.Diagnostics.Debug.WriteLine("La conexión se abrio exitosamente");
                    

                    return RedirectToAction("/Menu");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exite un error con la conexion " + ex.Message);
                TempData["MensajeError"] = "Error al conectar: " + ex.Message;

                return RedirectToAction("Index");
            }
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
