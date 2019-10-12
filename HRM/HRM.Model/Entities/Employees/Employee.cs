using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities.Request;

namespace HRM.Model.Entities.Employees
{
    public class Employee : BaseEntity
    {
        
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [EmailAddress]     
        public string Email { get; set; }
        
        [Required]
        public string EmployeeName { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required] public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime HireDay { get; set; }

        public Guid PositionId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int BasicSalary { get; set; }

        [Required] [Range(1, 100)] public decimal Coefficient { get; set; }

        public Guid UnitId { get; set; }

        [Required]
        [DisplayName("Unit Manager")]
        public Boolean IsManager { get; set; }

        public Position.Position Position { get; set; }
        public Unit.Unit Unit { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
    }
}
