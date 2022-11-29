using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TWANCOSMETICS.Code;
using TWANCOSMETICS.Dao;
using AutoMapper;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product(int page = 1, int pageSize = 1, string sort = "")
        {
            int totalRecord = 0;
            var brand= DataProvider.Ins.DB.Brand.Select(x => x).ToList();
            ViewBag.Brand = brand;
           var model = new ProductDao().ListProduct(ref totalRecord, page, pageSize,sort);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 1;
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
        public ActionResult ProductCategory(int cateID, int page = 1, int pageSize = 1, string sort = "")
        {
            StringHelper.pageActive = "ProductCategory";
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateID,ref totalRecord, page, pageSize,sort);         
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 1;
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

        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            var model = DataProvider.Ins.DB.Category.Select(x => x).ToList();

            return View(model);
        }
        [ChildActionOnly]
        public ActionResult BrandList()
        {
            var model = DataProvider.Ins.DB.Brand.Select(x => x).ToList();

            return PartialView(model);
        }

    }
}