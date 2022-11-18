using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TWANCOSMETICS.Models
{
    public class RegisterModel
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn phải nhập tên của bạn")]
        public string FullName { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email..")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Mật khẩu phải chứa: mật khẩu phải có ít nhất 8 ký tự, 1 ký tự in hoa, 1 ký tự thường và 1 số")]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp vui lòng thử lại")]
        [DataType(DataType.Password)]
        public string Confirmpwd { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại..")]
        [RegularExpression(@"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn giới tính..")]
        public string gender { get; set; }
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