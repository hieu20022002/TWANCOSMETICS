using Microsoft.Build.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using TWANCOSMETICS.Dao;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";
        public ActionResult Cart()
        {
            var User = Session["Account"] as User;

            
            List<CartItem> list = new List<CartItem>();
            if (User != null)
            {
                 list = new CartDao().cartitems(User.id);
                return View(list);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        
        
        
        public ActionResult AddItem(int productId)
        {
            
            var User= Session["Account"] as User;
            if (User== null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                bool result = new CartItem().AddCart(User.id,productId);
                if (result == true && ModelState.IsValid)
                {
                    
                    return RedirectToAction("Cart", "Cart");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                    return View();

                }
            }
            return View();
           
        }
    }
}