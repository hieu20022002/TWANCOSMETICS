using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWANCOSMETICS.Models;

namespace TWANCOSMEICS.Models
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }
        public twancosmeticsEntities DB { get; set; }
        private DataProvider()
        {
            DB = new twancosmeticsEntities();
        }
    }
}