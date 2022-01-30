using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class Factory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string FactoryCode { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}