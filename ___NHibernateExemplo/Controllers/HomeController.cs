using NHibernate;
using NHibernateExemplo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NHibernateExemplo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ISession session;

		public HomeController()
		{
			session = NHibernateHelper.OpenSession();
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public IList<Aluno> GetAll()
		{
			return session.Query<Aluno>().ToList();
		}
	}
}