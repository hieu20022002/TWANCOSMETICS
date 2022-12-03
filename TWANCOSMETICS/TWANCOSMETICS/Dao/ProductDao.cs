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
        public List<ProductViewModel> Search(string keyword,List<ProductViewModel> product)
        {
            var model =product.Where(x =>x.status==1 && (x.name.Contains(keyword) || 
                                    x.Category.Contains(keyword) ||
                                    x.Brand.Contains(keyword) || 
                                    x.variant.Contains(keyword)) ).ToList();
            return model;
        }
    }
}