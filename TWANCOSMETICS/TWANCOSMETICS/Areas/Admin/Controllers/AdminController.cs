using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Areas.Admin.Models;
using TWANCOSMETICS.Dao;

namespace TWANCOSMETICS.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
       
        public ActionResult Index()
        {
            int quantity_Cus = DataProvider.Ins.DB.User.Where(x => x.role_id == 11).Count();
            int quantity_Pro = DataProvider.Ins.DB.Product.Count();
            int quantity_Ord = DataProvider.Ins.DB.Order.Count();
            decimal quantity_DT = new OrderDao().DoanhThu();
            ViewBag.Cus = quantity_Cus;
            ViewBag.Pro = quantity_Pro;
            ViewBag.Ord = quantity_Ord;
            ViewBag.DoanhThu = quantity_DT;

            return View();
        }
        
        public ActionResult Chart()
        {
                DateTime ToDate = DateTime.Now;
                DateTime FromDate = ToDate.AddYears(-1);
            
            List<DataPoint> dataPoints = new List<DataPoint>();
            var data = DataProvider.Ins.DB.Order.Where(x => x.created_at >= FromDate && x.created_at <= ToDate && x.paid == 1).GroupBy(x => new { Total = x.total, Month = x.created_at.Month }).Select(y => new DataPoint{ x = (int)y.Key.Month, y = (decimal)y.Sum(c => c.total) }).ToList();

            //foreach (var response in data)
            //{
            //    point = new DataPoint((int)response.Month, (int)response.Total);
            //    dataPoints.Add(point);
            //}
            
            
            ViewBag.DataPoints = ViewBag.DataPoints = JsonConvert.SerializeObject(data, _jsonSetting);
            return View();
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        
        //[HttpPost]
        //public JsonResult AjaxChart()
        //{
        //    DateTime FromDate= new DateTime(); DateTime ToDate= DateTime.Now;
        //    List<object> iData = new List<object>();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Time", System.Type.GetType("System.Int32"));
        //    dt.Columns.Add("Total", System.Type.GetType("System.Decimal"));
        //    var delayedResponses = DataProvider.Ins.DB.Order.Where(x => x.created_at >= FromDate && x.created_at <= ToDate && x.paid == 1).GroupBy(x=> new { Total = x.total , Month=x.created_at.Month }).Select(y=> new {Month=y.Key.Month,Total=y.Sum(c => c.total)});

        //    var commonResponses = DataProvider.Ins.DB.Order.Where(x => x.created_at >= FromDate && x.created_at <= ToDate && x.paid == 1).Select(x => new { quarter = (int)System.Data.Entity.SqlServer.SqlFunctions.DatePart("quarter", x.created_at) }).Distinct();
        //    DataRow dr = dt.NewRow();
        //    foreach (var response in delayedResponses)
        //    {
        //        dr= dt.NewRow();
        //        dr["Time"] = response.Month;
        //        dr["Total"] = response.Total;
        //        dt.Rows.Add(dr);
        //    }
        //    foreach (DataColumn dc in dt.Columns)
        //    {
        //        List<object> x = new List<object>();
        //        x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
        //        iData.Add(x);
        //    }

        //    return Json(iData, JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        //public JsonResult GetChart(DateTime FromDate, DateTime ToDate)
        //{
        //    List<object> chartData = new List<object>();
        //    var dtQuarter = DataProvider.Ins.DB.Order.Where(x => x.created_at >= FromDate && x.created_at <= ToDate && x.paid == 1).Select(x => new { quarter = (int)System.Data.Entity.SqlServer.SqlFunctions.DatePart("quarter", x.created_at) }).Distinct();
        //    List<int> labels = new List<int>();
        //    foreach (var dt in dtQuarter)
        //    {

        //        labels.Add(dt.quarter);
        //    }
        //    chartData.Add(labels);
        //    var dtDoanhSo = DataProvider.Ins.DB.Order.Where(x => x.created_at >= FromDate && x.created_at <= ToDate && x.paid == 1).Select(x => new { quarter = (int)System.Data.Entity.SqlServer.SqlFunctions.DatePart("quarter", x.created_at), total = x.total });
        //    var dtBieuDo = dtDoanhSo.GroupBy(x => x.quarter).Select(x => new BieuDo { Total = x.Sum(y => y.total), Quarter = (int)x.First().quarter });
        //    List<decimal> series1 = new List<decimal>();
        //    foreach (var dt1 in dtBieuDo)
        //    {
        //        series1.Add(dt1.Quarter);
        //    }
        //    chartData.Add(series1);
        //    StaticsModel chart = new StaticsModel();
        //    chart.Chart = chartData;
        //    return Json(new
        //    {
        //        labels = labels,
        //        data = series1,
        //        Total = dtBieuDo.Sum(x => x.Total),
        //        status = true
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}