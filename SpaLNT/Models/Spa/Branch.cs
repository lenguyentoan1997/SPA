using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        public string BranchName { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Branch Phone is required")]
        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string ContactVia { get; set; }

        [MaxLength(50)]
        public string BranchCode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}