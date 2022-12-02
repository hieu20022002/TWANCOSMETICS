using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWANCOSMEICS.Models;
using PagedList;
using TWANCOSMETICS.Dao;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int cateID=0, int brandID=0,int page = 1, int pageSize = 5, string sort = "")
        {

            Session["cateID"] = cateID;
            Session["brandID"]= brandID;
            //int totalRecord = 0;
            
            var model = new ProductDao().ListProduct(sort, cateID, brandID);
            //ViewBag.Total = totalRecord;
            //ViewBag.Page = page;
            //int maxPage = 5;
            //int totalPage = 0;
            //totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            //ViewBag.TotalPage = totalPage;
            //ViewBag.MaxPage = maxPage;
            //ViewBag.First = 1;
            //ViewBag.Last = totalPage;
            //ViewBag.Next = page + 1;
            //ViewBag.Prev = page - 1;
            ViewBag.SortKey = sort;
            Session["Product"] = model;
            return View(model.ToPagedList(page, pageSize));
        }
        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            var model = DataProvider.Ins.DB.Category.ToList();

            return View(model);
        }
        [ChildActionOnly]
        public ActionResult BrandList()
        {
            var model = DataProvider.Ins.DB.Brand.Where(x => x.status==1).ToList();

            return View(model);
        }

    }
}