using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using p10.Common;
using Model.Dao;
using p10.Areas.Admin.Models;
using System.Drawing.Printing;
using System.Web.UI;
using System.Web.Services.Description;
using System.Runtime.Remoting.Messaging;
using PagedList;
using static Model.Dao.IndexDao;

namespace p10.Areas.Admin.Controllers

{
    public class ProfilesController : BaseController
    {
        P10DbContext db;
        // GET: Admin/Profiles
        public ActionResult Index(string search = "")
        {
            P10DbContext db = new P10DbContext();
            List<Profiles> profile = db.Profiles.Where(x=>x.name.Contains(search)).ToList();
            return View(profile);
        }

     

        public ActionResult Detail(int id)
        {
            P10DbContext db = new P10DbContext();
            Profiles name = db.Profiles.Where(x=>x.ProfilesID==id).FirstOrDefault();
            return View(name);
        }
        //sua
        public ActionResult Edit(int id)
        {
            P10DbContext db = new P10DbContext();
            Profiles profiles = db.Profiles.Where(x => x.ProfilesID == id).FirstOrDefault();
            return View(profiles);
        }
        public ActionResult Delete(int id)
        {
            P10DbContext db = new P10DbContext();
            Profiles profiles = db.Profiles.Where(x => x.ProfilesID == id).FirstOrDefault();
            return View(profiles);
        }
        [HttpPost]
        public ActionResult Delete(int id, int a)
        {
            P10DbContext db = new P10DbContext();
            Profiles profiles = db.Profiles.Where(x => x.ProfilesID == id).FirstOrDefault();
            db.Profiles.Remove(profiles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Profiles entity)
        {
            
            db = new P10DbContext();
            db.Profiles.Add(entity);
            db.SaveChanges();

            return View();
        }


        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase uploadedFiles)
        {
            string returnImagePath = string.Empty;
            string fileName;
            string Extension;
            string imageName;
            string imageSavePath;

            if (uploadedFiles.ContentLength > 0)
            {
                fileName = Path.GetFileNameWithoutExtension(uploadedFiles.FileName);
                Extension = Path.GetExtension(uploadedFiles.FileName);
                imageName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");
                imageSavePath = Server.MapPath("/postedImage/") + imageName + Extension;

                uploadedFiles.SaveAs(imageSavePath);
                returnImagePath = "/postedImage/" + imageName + Extension;
            }

            return Json(Convert.ToString(returnImagePath), JsonRequestBehavior.AllowGet);
        }
    }
}