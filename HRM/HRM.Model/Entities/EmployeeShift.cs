using System;
using HRM.Model.Entities.Employees;
using HRM.Model.Entities.Shifts;

namespace HRM.Model.Entities
{
    public class EmployeeShift : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid ShiftId { get; set; }
        
        public virtual Employee Employees { get; set; }
        public virtual Shift Shifts { get; set; }
    }
}