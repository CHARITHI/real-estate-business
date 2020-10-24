using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace real_estate_business.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String OwnerNo { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Address { get; set; }
        public String TelNo { get; set; }

        public List<Rent> Rent { get; set; } //An owner can have multiple renting buildings
    }
}