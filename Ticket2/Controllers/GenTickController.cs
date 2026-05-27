using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticket2.Models.clases;

namespace Ticket2.Controllers
{
    public class GenTickController : Controller
    {
        // GET: GenTick
        public ActionResult Index()
        {
            return View();
        }
        private readonly RepositorioBase _repositorio;

        public GenTickController()
        {
            _repositorio = new RepositorioBase();
        }

        public ActionResult GenTickets()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var tickets = _repositorio.ObtenerTodos();

            return View(tickets);
        }

        [HttpPost]
        public ActionResult CrearTicket(Ticket ticket)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (string.IsNullOrWhiteSpace(ticket.Asunto))
            {
                ViewData["Error"] = "El asunto del ticket es obligatorio.";
                return View("GenTickets", _repositorio.ObtenerTodos());
            }

            _repositorio.Crear(ticket);

            return RedirectToAction("GenTickets");
        }

        [HttpPost]
        public ActionResult EliminarTicket(int id)
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            _repositorio.Eliminar(id);

            return RedirectToAction("GenTickets");
        }
    }
}