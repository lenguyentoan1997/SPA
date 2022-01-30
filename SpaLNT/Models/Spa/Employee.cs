using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaLNT.Models.Spa
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public decimal Salary { get; set; }

        public string EmployeeCode { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual ICollection<UseService> UseServices { get; set; }
    }
}