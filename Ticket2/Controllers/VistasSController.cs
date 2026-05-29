using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket2.Models.clases;

namespace Ticket2.Controllers
{
    public class VistasSController: Controller
    {

        // GET: Vistas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vistas/Menu
        [ValidarSesion]
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult GenTickets()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vistas/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}