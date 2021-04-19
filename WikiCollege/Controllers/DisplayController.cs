using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiCollege.Models.Dao;

namespace WikiCollege.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult Index(int id = 1)
        {
            var x = new ContentDao().getByID(id);
            int count = new ContentDao().updateView(x);
            return View(x);
        }
    }
}