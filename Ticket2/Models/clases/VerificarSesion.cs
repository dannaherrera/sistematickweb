using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TuProyecto.Models.clases 
{
    public class VerificarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Usuario"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index" })
                );
            }

            base.OnActionExecuting(filterContext);
        }
    }
}