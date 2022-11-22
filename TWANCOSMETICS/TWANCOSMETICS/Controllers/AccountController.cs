using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Account()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register() { return View(); }
        [HttpGet]
        public ActionResult Login() { return View(); }
        [HttpGet]
        public ActionResult InfoManagement(int? id) {
            if (Session["Account"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }
        //public ActionResult EditAddress() {
        //    if (Session["Account"] != null)
        //    {
        //        //User user = DataProvider.Ins.DB.User.Find(id);
        //        //if (user == null)
        //        //{
        //        //    return HttpNotFound();
        //        //}
        //        //else
        //        //{

        //        //}


        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            
            string result = new AccountModel().Register(model);
            if (result == null && ModelState.IsValid)
            {
                var fName = DataProvider.Ins.DB.User.Where(x => x.username == model.UserName).FirstOrDefault();
                Session["Account"] = fName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", result);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if(model.username != null)
            {               
                if(model.password != null)
                {
                    var result = new AccountModel().Login(model.username, model.password);
                    if (result && ModelState.IsValid)
                    {
                        var fName = DataProvider.Ins.DB.User.Where(x => x.username == model.username).FirstOrDefault();
                        Session["Account"] = fName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditAddress(AddresModel model)
        //{
        //    var user = Session["Account"] as User;
        //    string result = new AccountModel().EditAddress(model, user.id);
        //    if (result == null && ModelState.IsValid)
        //    {
        //        return RedirectToAction("InfoManagement", "Account");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", result);
        //    }
        //        return View(model);

        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InfoManagement(User model)
        {
            var user = Session["Account"] as User;
            string result = new AccountModel().InfoManagement(user.id, model.username, model.fullname, model.email, model.phoneNumber, model.gender);
            if(result == null && ModelState.IsValid)
            {
                return RedirectToAction("InfoManagement", "Account");
            }
            else
            {
                ModelState.AddModelError("", result);
            }
            return View(model);

        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            return Redirect("/");
        }
        public ActionResult Cancel()
        {

              ViewData["Cancel"] = Request.Headers["Cancel"].ToString();
            return (ActionResult)ViewData["Cancel"];

        }
    }
}