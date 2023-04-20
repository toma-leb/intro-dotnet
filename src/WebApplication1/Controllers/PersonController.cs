using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataProvider;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        public PersonRepository persRepository = new PersonRepository();
        public ActionResult Index()
        {
            List<Person> persList = persRepository.GetAll().ToList();
            ViewBag.NbColumns = 4;
            return View(persList);
        }
    }
}