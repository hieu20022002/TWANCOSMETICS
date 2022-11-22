using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWANCOSMETICS.Dao;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Product(int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDao().ListProduct(ref totalRecord,page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}