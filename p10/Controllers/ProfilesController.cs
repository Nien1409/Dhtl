using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p10.Controllers
{
    public class ProfilesController : Controller
    {
        // GET: Profiles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachGiaoVien(string search="")
        {
            P10DbContext db = new P10DbContext();
            List<Profiles> profile = db.Profiles.Where(x => x.name.Contains(search)).ToList();
            return View(profile);
        }

        public ActionResult DetailDanhSachGiaoVien(int id)
        {
            P10DbContext db = new P10DbContext();
            Profiles profiles = db.Profiles.Where(row => row.ProfilesID == id).FirstOrDefault();
            return View(profiles);
        }
    }
}