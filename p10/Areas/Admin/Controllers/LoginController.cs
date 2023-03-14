using p10.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using p10.Common;

namespace p10.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModels models) //model gửi vào dữ liệu login từ web gán vào models
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(models.Name, Encryptor.MD5Hash(models.Password));
                if (result == 1)
                {
                    var user = dao.GetbyId(models.Name);
                    var userSession = new UserLogin();
                    userSession.Name = user.Name;
                    userSession.UsersID = user.UsersID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    
                    //Viewbag.Add(user.UsersID, userSession); // gán UserID vào viewbag hoặc một biến multicontroller thông qua viewbag hoặc 1 dữ liệu
                    return RedirectToAction("index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản chưa được kích hoạt.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("","Password sai.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View("Index");
        }
    }
}