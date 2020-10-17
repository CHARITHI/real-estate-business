using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace real_estate_business.Models
{
    public class Owner
    {
        [Key]
        public String OwnerNo { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Address { get; set; }
        public int TelNo { get; set; }

        public List<Rent> Rent { get; set; } //An owner can have multiple renting buildings
    }
}