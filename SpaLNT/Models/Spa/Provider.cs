using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(450)]
        public string ProviderCode { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrderProvider> OrderProviders { get; set; }
    }
}