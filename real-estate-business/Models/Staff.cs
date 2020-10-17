using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace real_estate_business.Models
{
    public class Staff
    {
        [Key]
        public String StaffNo { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Position { get; set; }
        public DateTime DOB { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Branch")]
        public String Branch_BranchNoRef { get; set; }
    }
}