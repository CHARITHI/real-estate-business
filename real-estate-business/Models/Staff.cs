using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace real_estate_business.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public String StaffNo { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Position { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName="date")]
        public DateTime DOB { get; set; }
        public int Salary { get; set; }

        [ForeignKey("Branch")]
        public String Branch_BranchNoRef { get; set; }
        public virtual Branch Branch { get; set; }

        public List<Rent> Rent { get; set; }

    }
}