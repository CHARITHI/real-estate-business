using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace real_estate_business.Models
{
    public class Branch
    {
        [Key]
        public String BranchNo { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String PostCode { get; set; }
    }
}