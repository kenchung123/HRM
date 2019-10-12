using System;
using System.ComponentModel.DataAnnotations;
using HRM.Model.Entities.Employees;

namespace HRM.Model.Entities.Request
{
    public class ApproveDayOff : BaseEntity
    {
        [Required] public Guid TimeOffId { get; set; }
        [Required] public Guid EmployeeId { get; set; }
        [Required] public string Status { get; set; }
        [Required] public Guid RequestTypeId { get; set; }
        [Required] public Guid ApproverId { get; set; }

        public virtual TimeOff TimeOff { get; set; }
        public virtual RequestType RequestType { get; set; }
        
    }
}