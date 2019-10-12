using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities.Employees;

namespace HRM.Model.Entities.Position
{
    public class Position : BaseEntity
    {
       
        
        [Required]
        [StringLength(30)]
        public string PositionName { get; set; }
        
        [Required]
        public string Note { get; set; }
        
       public virtual ICollection<Employee> Employees { get; set; }
       
    }
}