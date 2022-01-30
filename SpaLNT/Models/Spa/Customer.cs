using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string CustomerCode { get; set; }

        public string Name { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string IdentityCard { get; set; }

        public string Job { get; set; }

        [MaxLength(5)]
        public string Gender { get; set; }

        public string DOB { get; set; }

        public string Avatar { get; set; }

        public virtual ICollection<OrderCustomer> OrderCustomers { get; set; }
        public virtual ICollection<BookingService> BookingServices { get; set; }
    }
}