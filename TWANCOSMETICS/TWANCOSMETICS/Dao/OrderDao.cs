using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWANCOSMEICS.Models;

namespace TWANCOSMETICS.Dao
{
    public class OrderDao
    {
        public decimal DoanhThu()
        {
            decimal? doanhthu = (decimal)DataProvider.Ins.DB.Order.Where(x => x.paid == 1).Select(x => x.total).Sum();
            if(doanhthu.HasValue)
                return doanhthu.Value;
            else return 0;
            
        }

    }
}