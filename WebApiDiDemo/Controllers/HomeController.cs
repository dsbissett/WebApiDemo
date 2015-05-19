using System;
using System.Web.Mvc;
using Business.Interfaces;

namespace WebApiDiDemo.Controllers
{
    public class HomeController : Controller
    {
        private IPersonLogic _personLogic;

        public HomeController(IPersonLogic personLogic)
        {
            _personLogic = personLogic;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            var id = new Guid("57732A6C-9C59-F78E-C5A8-6E5AF119A407");

            var result = _personLogic.GetById(id);

            return View(result);
        }
    }
}