using SistemaTickets.Models;
using SistemaTickets.Models.Clases;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Mvc;


namespace SistemaTickets.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }   

        public ActionResult Conexion()
        {
            ConexionBD newconexionBD = new ConexionBD();
            TempData["NombreConexion"] = "DefaultConnection";


            try
            {
                using (SqlConnection conexion = newconexionBD.ObtenerConexion())
                {
                    conexion.Open();
                    System.Diagnostics.Debug.WriteLine("Conexión a la base de datos establecida con éxito para: DefaultConnection");
                    TempData["MensajeExito"] = "Conexión a la base de datos establecida con éxito";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Hay un error al tratar de conectar a la BD");
               TempData["MensajeError"] = "Error al conectar con la base de datos: " + ex.Message;
            }

            return View();

        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
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

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
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

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
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