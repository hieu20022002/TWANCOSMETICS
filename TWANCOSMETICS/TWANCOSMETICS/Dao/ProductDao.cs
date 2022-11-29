﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Dao
{
    public class ProductDao
    {
        twancosmeticsEntities db = new twancosmeticsEntities();
        public ProductDao()
        {
            db = new twancosmeticsEntities();
        }
        public List<ProductViewModel> ListProduct( ref int totalRecord, int pageIndex = 1, int pageSize = 1, string sort = "")
        {
            totalRecord = DataProvider.Ins.DB.Product.Count();
            var model1 = DataProvider.Ins.DB.Product.Join(DataProvider.Ins.DB.Image,
                                                        p => p.image_id, i => i.id, (p, i) =>
                                                        new { p, u_image = i.u_image });
            var model2 = model1.Join(DataProvider.Ins.DB.Category,
                                                        pi => pi.p.category_id, c => c.id, (pi, c) =>
                                                        new { pi, Category = c.name });

            var model3 = model2.Join(DataProvider.Ins.DB.Brand,
                                                          pc => pc.pi.p.brand_id, b => b.id, (pc, b) => new { pc, Brand = b.name });
            var model = DataProvider.Ins.DB.Inventory.Join(model3, i => i.product_id, m => m.pc.pi.p.id, (i,m) =>
                                                          new {
                                                                  id =i.product_id, 
                                                                  name =m.pc.pi.p.name,
                                                                  description= m.pc.pi.p.description,
                                                                  Brand = m.Brand,
                                                                  Category = m.pc.Category,
                                                                  u_image = m.pc.pi.u_image,
                                                                  price = i.price,
                                                                  quantity =i.quantity,
                                                                  variant =i.variant,
                                                                  date_created=i.date_created,
                                                                  date_updated=i.date_updated,
                                                                  status = m.pc.pi.p.status,
                                                                  delete_flag = m.pc.pi.p.delete_flag
                                                              }).AsEnumerable().Select(x => new ProductViewModel()
                                                              {
                                                                  id=x.id,
                                                                  name=x.name,
                                                                  description=x.description,
                                                                  Brand =x.Brand,
                                                                  Category=x.Category,
                                                                  price = x.price,
                                                                  u_image=x.u_image,
                                                                  quantity =x.quantity,
                                                                  variant=x.variant,
                                                                  date_created=x.date_created,
                                                                  date_updated=x.date_updated,
                                                                  status=x.status,
                                                                  delete_flag=x.delete_flag,
                                                                  ListPrice = ListPrices((int)x.id) });

            
            
            switch (sort)
            {
                case "price_asc":
                    model = model.OrderBy(x => x.price);
                    break;
                case "price_des":
                    model = model.OrderByDescending(x => x.price);
                    break;
                default:
                    model.OrderByDescending(x => x.date_created).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    break;
            }
            model = model.DistinctBy(m => m.id);
            return model.ToList();
        }
        public List<int> ListPrices(int id)
        {
            List<int> price = new List<int>();

                var model1= DataProvider.Ins.DB.Inventory.Where(x => x.product_id == id);
                model1.OrderBy(x => x.price);

                foreach (var x in model1)
                {
                    price.Add((int)x.price);
                }
            price.Sort();
            return price;
        }
        public string Category(int categoryID)
        {
            var model = DataProvider.Ins.DB.Category.Where(x => x.id == categoryID).Select(x =>x.name);
            return model.ToString();
        }
        public string Brand(int BrandID)
        {
            var model = DataProvider.Ins.DB.Brand.Where(x => x.id == BrandID).Select(x => x.name);
            return model.ToString();
        }
        public string Image (int? ImageID)
        {
            var model = DataProvider.Ins.DB.Image.Where(x => x.id == ImageID).Select(x => x.u_image);
            return model.ToString();
        }

        public List<ProductViewModel> ListByCategoryId(int categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2,string sort="")
        {
            
       
                totalRecord = DataProvider.Ins.DB.Product.Where(m => m.category_id == categoryID).Count();
                var model1 = DataProvider.Ins.DB.Product.Join(DataProvider.Ins.DB.Image,
                                                            p => p.image_id, i => i.id, (p, i) =>
                                                            new { p, u_image = i.u_image });
                
                var model = DataProvider.Ins.DB.Inventory.Join(model1, i => i.product_id, m => m.p.id, (i, m) => new { i, m }).Where(x => x.m.p.category_id == categoryID).AsEnumerable().Select(
                                                               x => new ProductViewModel()
                                                               {
                                                                   id = x.m.p.id,
                                                                   name = x.m.p.name,
                                                                   description = x.m.p.description,
                                                                   Brand = Brand(x.m.p.brand_id),
                                                                   Category = Category(x.m.p.category_id),
                                                                   price = x.i.price,
                                                                   u_image = x.m.u_image,
                                                                   quantity = x.i.quantity,
                                                                   variant = x.i.variant,
                                                                   date_created = x.i.date_created,
                                                                   date_updated = x.i.date_updated,
                                                                   status = x.m.p.status,
                                                                   delete_flag = x.m.p.delete_flag,
                                                                   ListPrice = ListPrices((int)x.m.p.id)
                                                               });
            switch (sort)
            {
                case "price_asc":
                    model = model.OrderBy(x => x.price);
                    break;
                case "price_des":
                    model = model.OrderByDescending(x => x.price);
                    break;
                default:
                    model.OrderByDescending(x => x.date_created).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                    break;
            }
            model = model.DistinctBy(m => m.id);
            return model.ToList();

        }
    
    }
}