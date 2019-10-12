using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities.Employees;

namespace HRM.Model.ViewModel.Position
{
    public class PositionViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(30)]
        public string PositionName { get; set; }
        
        [Required]
        public string Note { get; set; }
        
      //  public virtual ICollection<Employee> Employees { get; set; }
    }
}