using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDWebAPI_Cliente.Models
{
    public class Product
    {
        [Display(Name = "ContatoID")]
        public int ContatoID { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}