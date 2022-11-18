using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TWANCOSMETICS.Models
{
    public class AddresModel
    {
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ..")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn tỉnh/thành phố..")]
        public string City { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn quận/huyện..")]
        public string District { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn xã/phường..")]
        public string Ward { get; set; }
        public string Address()
        {
            return this.Region + ", " + this.Ward + ", " + this.District + ", " + this.City + ".";
        }
    }
}