using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Dao
{
    public class ProductDao
    {
        public List<int> ListPrices(int id)
        {
            List<int> price = new List<int>();

            var model1 = DataProvider.Ins.DB.Inventory.Where(x => x.product_id == id);
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
            var model = DataProvider.Ins.DB.Category.Where(x => x.id == categoryID).Select(x => x.name);
            return model.ToString();
        }
        public string Brand(int BrandID)
        {
            var model = DataProvider.Ins.DB.Brand.Where(x => x.id == BrandID).Select(x => x.name);
            return model.ToString();
        }
        public string Image(int? ImageID)
        {
            var model = DataProvider.Ins.DB.Image.Where(x => x.id == ImageID).Select(x => x.u_image);
            return model.ToString();
        }

        public List<ProductViewModel> ListProduct(string sort = "", int cateID = 0, int brandID = 0)
        {


            

            var productimage = DataProvider.Ins.DB.Product.Join(DataProvider.Ins.DB.Image,
                                           p => p.image_id, i => i.id, (p, i) =>
                                           new { p, u_image = i.u_image });

            if (cateID != 0 && brandID==0)
            {
                productimage = productimage.Where(x => x.p.category_id == cateID);
            }
            else if(brandID != 0 && cateID==0)
            {
                productimage = productimage.Where(x => x.p.brand_id == brandID);
            }
            else if(cateID != 0 && brandID != 0)
            {
                productimage = productimage.Where(x => x.p.brand_id == brandID && x.p.category_id == cateID);
            }

            var model = DataProvider.Ins.DB.Inventory.Join(productimage, i => i.product_id, m => m.p.id, (i, m) => new { i, m }).AsEnumerable().Select(
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
                    model = model.OrderByDescending(x => x.date_created);
                    break;
            }
            
            model = model.DistinctBy(x => x.id);
            return model.ToList();
        }
        public List<ProductViewModel> Search(string keyword, string sort = "", int cateID = 0, int brandID = 0)
        {
            var productimage = DataProvider.Ins.DB.Product.Join(DataProvider.Ins.DB.Image,
                               p => p.image_id, i => i.id, (p, i) =>
                               new { p, u_image = i.u_image });
            if (cateID != 0 && brandID == 0)
            {
                productimage = productimage.Where(x => x.p.category_id == cateID);
            }
            else if (brandID != 0 && cateID == 0)
            {
                productimage = productimage.Where(x => x.p.brand_id == brandID);
            }
            else if (cateID != 0 && brandID != 0)
            {
                productimage = productimage.Where(x => x.p.brand_id == brandID && x.p.category_id == cateID);
            }

            var model = DataProvider.Ins.DB.Inventory.Join(productimage, i => i.product_id, m => m.p.id, (i, m) => new { i, m }).AsEnumerable().Select(
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
                    model = model.OrderByDescending(x => x.date_created);
                    break;
            }

            model = model.DistinctBy(x => x.id);
            var listproduct =model.Where(x =>x.status==1 && (x.name.Contains(keyword) || 
                                    x.Category.Contains(keyword) ||
                                    x.Brand.Contains(keyword) || 
                                    x.variant.Contains(keyword)) ).ToList();
            return listproduct.ToList();
        }
        public List<ProductViewModel> Detail(int ID)
        {
            var model = DataProvider.Ins.DB.Product.Where(p => p.id == ID).Join(
                            DataProvider.Ins.DB.Inventory,p => p.id, i => i.product_id, (p,i) =>
                                new {id=p.id,
                                     name = p.name,
                                     description = p.description,
                                     brand_id=p.brand_id,
                                     category_id=p.category_id,
                                     image_id = p.image_id,
                                     price=i.price,
                                     ListPrice= ListPrices(ID),
                                     quantity=i.quantity,
                                     variant=i.variant,
                                     date_created=i.date_created,
                                     date_updated = i.date_updated,
                                     status=p.status,
                                     delete_flag=p.delete_flag });
            
            var product = model.Join(DataProvider.Ins.DB.Image,
                   m => m.image_id, i => i.id, (m, i) =>
                   new { m, u_image = i.u_image }).AsEnumerable().Select(
                        p => new ProductViewModel()
                        {
                            id=p.m.id,
                            name = p.m.name,
                            description = p.m.description,
                            Brand = Brand(p.m.brand_id),
                            Category = Category(p.m.category_id),
                            price = p.m.price,
                            u_image = p.u_image,
                            quantity = p.m.quantity,
                            ListPrice=p.m.ListPrice,
                            variant = p.m.variant,
                            date_created = p.m.date_created,
                            date_updated = p.m.date_updated,
                            status = p.m.status,
                            delete_flag = p.m.delete_flag
                        });
            return product.ToList();
        } 
    }
}