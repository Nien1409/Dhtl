using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using p10.Areas.Admin.Models;
using System.IO;
using Model.Dao;
using System.Drawing.Printing;
using System.Web.UI;
using static Model.Dao.PostDao;
using System.Web.Services.Description;
using System.Runtime.Remoting.Messaging;
using p10.Common;
using PagedList;

namespace p10.Areas.Admin.Controllers
 
{
    public class PostController : BaseController
    {
        P10DbContext db;
        // GET: Admin/Post
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new IndexDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        //edit
        public ActionResult Edit(int id)
        {
            P10DbContext db = new P10DbContext();
            Posts posts = db.Posts.Where(x=>x.PostsID == id).FirstOrDefault();
            return View(posts);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PostDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(Posts entity)
        {
            db = new P10DbContext();
            db.Posts.Add(entity);
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