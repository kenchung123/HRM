using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.ViewModel.Shifts
{
    public class ShiftViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(30)]
        public string ShiftName { get; set; }
        
        [Required]
        public float Marks { get; set; }
       
    }
}