using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Dao
{
    public class BrandDao
    {
        public Brand ViewDetail(int id)
        {
            return DataProvider.Ins.DB.Brand.Find(id);
        }
    }
}