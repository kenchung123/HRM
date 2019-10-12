using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.Entities.Shifts
{
    public class Shift : BaseEntity
    {
       
        [Required]
        [StringLength(30)]
        public string ShiftName { get; set; }
        
        [Required]
        public float Marks { get; set; }
        
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; }
    }
}