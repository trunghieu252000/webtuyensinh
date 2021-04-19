using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WikiCollege.Areas.Admin.Controllers
{
    public class MajorController : Controller
    {
        // GET: Admin/Major
        public ActionResult Index()
        {
            return View();
        }
    }
}