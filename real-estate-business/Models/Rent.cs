using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace real_estate_business.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public String PropertyNo { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String Ptype { get; set; }
        public int Rooms { get; set; }

        [ForeignKey("Owner")]
        public String OwnerNoRef { get; set; }
        public virtual Owner Owner { get; set; }

        [ForeignKey("Staff")]
        public String StaffNoRef { get; set; }
        public virtual Staff Staff { get; set; }

        [ForeignKey("Branch")]
        public String BranchNoRef { get; set; }
        public virtual Branch Branch { get; set; }

        public int Rent1 { get; set; }
    }
}