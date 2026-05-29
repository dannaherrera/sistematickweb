using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ticket2.Models.clases
{
    public class ValidarSesion: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UsuarioLogin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index" })
                );
            }

            base.OnActionExecuting(filterContext);
        }

    }
}