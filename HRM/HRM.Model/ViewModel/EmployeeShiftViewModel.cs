using System;
using HRM.Model.Entities.Employees;
using HRM.Model.Entities.Shifts;
using HRM.Model.ViewModel.Employees;
using HRM.Model.ViewModel.Shifts;

namespace HRM.Model.ViewModel
{
    public class EmployeeShiftViewModel
    { 
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ShiftId { get; set; }
        
       
    }
}