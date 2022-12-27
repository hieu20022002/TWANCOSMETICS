using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Dao
{
    public class CartDao
    {
        public List<CartItem> cartitems(int userid)
        {
            List<CartItem> cartitems = new List<CartItem>();
            CartItem cartitem = new CartItem();
            var model = DataProvider.Ins.DB.Cart.Where(c => c.user_id==userid);
            var model1 = DataProvider.Ins.DB.CartDetail.Join(model, m1 => m1.cart_id, m => m.id, (m1, m) => new { m1, m });
            var model2 = DataProvider.Ins.DB.Inventory.Join(model1, m2 => m2.id, cd => cd.m1.inventory_id, (m2, cd) => new { m2, cd });
            var model3 = DataProvider.Ins.DB.Product.Join(model2, m3 => m3.id, iv => iv.m2.product_id, (m3, iv) => new { m3, iv });
            var model4 = DataProvider.Ins.DB.Image.Join(model3, m4 => m4.id, p => p.m3.image_id, (m4, p) => new { m4.u_image, p }).
            Select(x => new CartItem() { 
                u_image = x.u_image,
                Product = x.p.m3,
                inventory = x.p.iv.m2, 
                cartdetail = x.p.iv.cd.m1,
                cart = x.p.iv.cd.m
                
        }).ToList();

            return model4;

        }
    }
}