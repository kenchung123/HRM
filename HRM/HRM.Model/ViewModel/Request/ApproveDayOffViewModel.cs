using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.Model.ViewModel.Request
{
    public class ApproveDayOffViewModel
    {
        [Key] public Guid Id { get; set; }

        [Required] public Guid TimeOffId { get; set; }
        [Required] public Guid EmployeeId { get; set; }
        [Required] public string Status { get; set; }
        [Required] public Guid RequestTypeId { get; set; }
        [Required] public Guid ApproverId { get; set; }
    }
}