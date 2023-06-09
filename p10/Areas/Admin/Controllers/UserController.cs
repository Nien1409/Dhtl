﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using System.Runtime.Remoting.Messaging;
using p10.Common;
using PagedList;

namespace p10.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        public ActionResult Edit(int id) 
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Users user)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var encryptedMd5PassWord = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5PassWord;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm User thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id) 
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Users user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encryptedMd5PassWord = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5PassWord;
                }
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật User thành công");
                }
            }
            return View("Index");
        }
    }
}