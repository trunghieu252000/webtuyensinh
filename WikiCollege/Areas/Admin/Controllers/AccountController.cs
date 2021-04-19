using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WikiCollege.Common;
using WikiCollege.Models.Dao;
using WikiCollege.Models.EF;

namespace WikiCollege.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Admin/Account
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new AccountDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        public ActionResult Edit(int id = 1)
        {
            var acc = new AccountDao().ViewDetail(id);
            var num = acc.acc_ID;
            return View(acc);
        }

        [HttpPost]
        public ActionResult Edit(ACCOUNT acc)
        {
            var x = acc.acc_ID;
            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                bool res = dao.Update(acc);
                if (res)
                {
                    ModelState.AddModelError("", "Cập nhật thành công!");
                    return RedirectToAction("Edit", "Account");
                }
                else
                    ModelState.AddModelError("", "Cập nhật không thành công!");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ACCOUNT acc)
        {

            if (ModelState.IsValid)
            {
                var dao = new AccountDao();
                acc.pass_word = Encryptor.MD5Hash(acc.pass_word);
                int res = dao.Insert(acc);
                if (res > 0)
                    return RedirectToAction("Index", "Account");
                else
                    ModelState.AddModelError("", "Thêm tài khoản thành công!");

            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var x = new AccountDao().Delete(id);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.Now.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Login");
        }
    }
}