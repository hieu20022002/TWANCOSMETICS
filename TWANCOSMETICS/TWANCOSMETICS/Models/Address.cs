//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TWANCOSMETICS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
    
        public virtual User User { get; set; }
    }
}
