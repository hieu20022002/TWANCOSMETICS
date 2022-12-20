using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Areas.Admin.Model;
using TWANCOSMETICS.Areas.Admin.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        [HttpGet]
        public ActionResult Login() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (model.username != null)
            {
                if (model.password != null)
                {
                    var result = new UserModel().Login(model.username, model.password);
                    if (result && ModelState.IsValid)
                    {
                        var fName = DataProvider.Ins.DB.User.Where(x => x.username == model.username).FirstOrDefault();
                        Session["Account"] = fName;
                        return RedirectToAction("Index", "Static");
                    }
                    else
                    {
                        if(DataProvider.Ins.DB.User.Where(x => x.username == model.username).SingleOrDefault() != null)
                        {
                            ModelState.AddModelError("", "Tài khoản không có quyền đăng nhập");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                        }
                        
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Vui lòng nhập mật khẩu");
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng nhập tên đăng nhập");
            }

            return View(model);
        }
    }
}