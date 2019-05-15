using System.Net;
using System.Web.Mvc;

namespace NHibernateExemplo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}
	}
}