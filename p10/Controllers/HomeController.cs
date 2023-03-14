using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Model.Dao;
using System.Runtime.Remoting.Messaging;
using p10.Common;
using PagedList.Mvc;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace p10.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TinTucSuKien(int page = 1, int pageSize = 4)
        {
            //P10DbContext db = new P10DbContext();
            //List<Posts> posts = db.Posts.OrderByDescending(x => x.PostsID).ToList();

            //Phantrang

            var dao = new IndexDao();
            var model = dao.ListAllPaging(page, pageSize);

            return View(model);
        }

        public ActionResult DetailTinTucSuKien(int id)
        {
             P10DbContext db = new P10DbContext();
            Posts posts = db.Posts.Where(row => row.PostsID == id).FirstOrDefault();
            return View(posts);
        }

        public ActionResult ThongTinChung()
        {
            return View();
        }
        public ActionResult TrietLyGiaoDuc()
        {
            return View();
        }
        public ActionResult TuyenSinh()
        {
            return View();
        }

    }
}