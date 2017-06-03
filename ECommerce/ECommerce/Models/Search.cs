using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Search
    {
        [Key]
        public int searchID { get; set; }

        public string description { get; set; }

        public bool buy { get; set; }

        public bool sell { get; set; }

        public bool trade { get; set; }
    }
}