using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiCollege.Models.EF;
using PagedList;


namespace WikiCollege.Models.Dao
{
    public class ContentDao
    {
        WikiCollegeDBContext db = new WikiCollegeDBContext();
        public IEnumerable<CONTENT> ListAllPaging(int page, int pageSize)
        {
            return db.CONTENT.OrderByDescending(x=> x.created_date).ToPagedList(page, pageSize);
        }
        public IEnumerable<CONTENT> ListAll()
        {
            return db.CONTENT.ToList();
        }

        public int Insert(CONTENT ct)
        {
            //if (ModelState.IsValid)
            {
                CONTENT obj = new CONTENT();
                //var author = new AccountDao().getByUserName((string)HttpContext.Current.Session["USER_SESSION"]);
                //string author_name = author.full_name;
                obj.author = 1;
                obj.meta_title = ct.meta_title;
                obj.title = ct.title;
                obj.desciption = ct.desciption;
                obj.image = ct.image;
                obj.detail = ct.detail;
                obj.created_date = DateTime.Now;
                obj.status = ct.status;
                if (ct.top_hot == null)
                    obj.top_hot = DateTime.Now.AddDays(7);
                else
                    obj.top_hot = ct.top_hot;
                obj.view_count = 0;
                obj.tags = ct.tags;
                db.CONTENT.Add(obj);
                db.SaveChanges();
            }
            return 1;
        }
        public CONTENT getByID(int id)
        {
            var x = db.CONTENT.Find(id);
            return db.CONTENT.Find(id);
        }

        public int updateView(CONTENT ct)
        {
            var content = db.CONTENT.Find(ct.content_ID);
            if (content.view_count == null)
                content.view_count = 1;
            else
                ++content.view_count;
            db.SaveChanges();
            return 1;
        }

        public bool Delete(int id)
        {
            var ct = db.CONTENT.Find(id);
            var x = db.CONTENT.Remove(ct);
            db.SaveChanges();
            return true;
        }
    }
}