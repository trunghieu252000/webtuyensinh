using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiCollege.Models.EF;
using PagedList;

namespace WikiCollege.Models.Dao
{
    public class CollegeDao
    {
        WikiCollegeDBContext db = new WikiCollegeDBContext();
        public IEnumerable<COLLEGE> ListAll()
        {
            return db.COLLEGE.ToList();
        }
        public IEnumerable<COLLEGE> ListAllPaging(int page, int pageSize)
        {
            return db.COLLEGE.OrderByDescending(x => x.area).ToPagedList(page, pageSize);
        }
    }
}