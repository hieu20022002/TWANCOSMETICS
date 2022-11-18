using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;
using TWANCOSMEICS.Models;

namespace TWANCOSMETICS.Models
{
    public class AccountModel
    {
        private twancosmeticsEntities _db = new twancosmeticsEntities();
        private User _user;
        public AccountModel()
        {
            _db = new twancosmeticsEntities();
        }
        public string Register(RegisterModel nUser)
        {
            
            
            User newuser = new User();
            var check = DataProvider.Ins.DB.User.FirstOrDefault(x => x.email == nUser.Email);
            var check1 = DataProvider.Ins.DB.User.FirstOrDefault(x => x.username == nUser.UserName);
            var check2 = DataProvider.Ins.DB.User.FirstOrDefault(x => x.phoneNumber == nUser.PhoneNumber);
            if (check != null)
            {
                return "Email đã tồn tại..";

            }
            else if (check1 != null)
            {
                return "Tên đăng nhập đã tồn tại";
            }
            else if (check2 != null)
            {
                return "Số điện thoại đã tồn tại";
            }
            else
            {
                newuser.fullname = nUser.FullName;
                if (nUser.gender == "Nam")
                {
                    newuser.gender = true;
                }
                else newuser.gender = false;

                newuser.email = nUser.Email;
                newuser.phoneNumber = nUser.PhoneNumber;
                newuser.username = nUser.UserName;
                if (nUser.Password != null)
                {
                    newuser.password = MD5Hash(nUser.Password);
                }
                newuser.role_id = 11;
                newuser.created_at = DateTime.Now;
                newuser.modifiled_at = DateTime.Now;
                DataProvider.Ins.DB.User.Add(newuser);

                try
                {
                    DataProvider.Ins.DB.SaveChanges();
                    return null;
                }
                catch (Exception e)
                {
                    
                    return "Đăng ký thất bại";
                }

            }

        }
        public bool Login(string userName, string password)
        {
            string _pass;
            if (password != null)
            {
                _pass = MD5Hash(password);
            }
            else _pass = null;
            _user = DataProvider.Ins.DB.User.Where(x => x.username == userName && x.password == _pass).SingleOrDefault();
            //var ketqua = from User in this.context.User where User.username == userName && User.password == password select User;
            if (_user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string InfoManagement(int iduser,string Username,string Fullname,string Email ,string sdt, bool sex)
        {
            if(Username == null)
            {
                return "Tên đăng nhập không được để trống";
            }
            else if(Fullname == null)
            {
                return "Họ tên không được để trống";
            }
            else if (Email == null)
            {
                return "Email không được để trống";
            }
            else if(sdt == null)
            {
                return "Số điện thoại không được để trống";
            }
            else
            {
                var check = DataProvider.Ins.DB.User.FirstOrDefault(x => x.email == Email && x.id!=iduser);
                var check1 = DataProvider.Ins.DB.User.FirstOrDefault(x => x.username == Username && x.id != iduser);
                var check2 = DataProvider.Ins.DB.User.FirstOrDefault(x => x.phoneNumber == sdt && x.id != iduser);
                if(check != null)
                {
                    return "Email đã tồn tại";

                }
                else if(check1 != null)
                {
                    return "Tên đăng nhập đã tồn tại";
                }
                else if (check2 != null)
                {
                    return "Số điện thoại đã tồn tại";
                }
                else if (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    return "Eamil không hợp lệ";
                }
                else if (!Regex.IsMatch(sdt, @"^\d{9,11}$"))
                {
                    return "Số điện thoại không hợp lệ";
                }
                else
                {
                    var user= DataProvider.Ins.DB.User.Where(m => m.id == iduser);
                    foreach(var u in user)
                    {
                        u.username = Username;
                        u.fullname = Fullname;
                        u.email = Email;
                        u.phoneNumber = sdt;
                    }
                    try
                    {
                        DataProvider.Ins.DB.SaveChanges();
                        return null;
                    }
                    catch (Exception e)
                    {
                        return "Cập nhật thất bại";
                    }
                }
            }
        }
        //public string EditAddress(AddressModel address, int iduser)
        //{
        //    var us = DataProvider.Ins.DB.User.Where(user => user.id == iduser);
        //    foreach(var user in us)
        //    {
        //        user.address = address.Address();
        //        user.city = address.City;
        //    }
        //    try
        //    {
        //        DataProvider.Ins.DB.SaveChanges();
        //        return null;
        //    }
        //    catch(Exception e)
        //    {
        //        return "Cập nhật thất bại";
        //    }
        //}

        private string MD5Hash(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(input);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;

        }
    }
}