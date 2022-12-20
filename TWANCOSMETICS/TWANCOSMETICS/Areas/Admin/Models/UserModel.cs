using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using TWANCOSMEICS.Models;
using TWANCOSMETICS.Models;

namespace TWANCOSMETICS.Areas.Admin.Models
{
    public class UserModel
    {
        private User _user;
        public bool Login(string userName, string password)
        {
            string _pass;
            if (password != null)
            {
                _pass = MD5Hash(password);
            }
            else _pass = null;
            _user = DataProvider.Ins.DB.User.Where(x => x.username == userName && x.password == _pass && x.role_id == 10).SingleOrDefault();
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