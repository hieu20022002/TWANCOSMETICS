using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Dao;

namespace TWANCOSMETICS.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Product { get; set; }
        public string u_image { get; set; }
        public Inventory inventory { get; set; }
        public Cart cart { get; set; }
        public CartDetail cartdetail { get; set; }

        public bool AddCart(int userID, int productID, int quantity=1)
        {
            
            var inventory = DataProvider.Ins.DB.Inventory.Where(x=>x.product_id== productID).FirstOrDefault();
            
            
            var model = DataProvider.Ins.DB.Cart.Where(x => x.user_id == userID).FirstOrDefault();
            if (model ==null )
            {
                Cart cart = new Cart();
                cart.user_id = userID;
                cart.date_created = DateTime.Now;
                cart.modifiled_at = DateTime.Now;
                DataProvider.Ins.DB.Cart.Add(cart);
                CartDetail cartdetail = new CartDetail();
                cartdetail.cart_id = cart.id;
                cartdetail.inventory_id = inventory.id;
                cartdetail.quantity = quantity;
                DataProvider.Ins.DB.CartDetail.Add(cartdetail);
                try
                {
                    DataProvider.Ins.DB.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
            else
            {
                CartDetail cartdetail = new CartDetail();
                cartdetail.cart_id = model.id;
                cartdetail.inventory_id = inventory.id;
                var model2 = DataProvider.Ins.DB.CartDetail.Where(x => x.cart_id == model.id && x.inventory_id == inventory.id).FirstOrDefault();
                if (model2 == null)
                {
                    cartdetail.inventory_id = inventory.id;
                    cartdetail.quantity = quantity;
                }
                else
                {
                    var updatquantity = DataProvider.Ins.DB.CartDetail.Where(x => x.inventory_id == inventory.id && x.cart_id == model.id);
                    foreach (var i in updatquantity)
                    {
                        i.quantity = i.quantity + quantity;

                    }
                    DataProvider.Ins.DB.SaveChanges();
                }
                
                DataProvider.Ins.DB.CartDetail.Add(cartdetail);
                try
                {
                    DataProvider.Ins.DB.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    return false;
                }

            }


        }
    }
}