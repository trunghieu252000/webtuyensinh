using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiCollege.Models.Dao;
using WikiCollege.Models.EF;

namespace WikiCollege.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ContentDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(CONTENT ct)
        {
            var dao = new ContentDao();
            int inserted = dao.Insert(ct);
            return View();
        }

        public ActionResult Display(int id)
        {
            return View("~View/Display/Index/" + id.ToString());
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var x = new ContentDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //var acc = new ContentDao()
            return View();
        }
    }
}