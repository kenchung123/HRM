using System;

namespace HRM.Model.ViewModel.Employees
{
    public class InfomationViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDay { get; set; }
        public string PositionName { get; set; }
        public int BasicSalary { get; set; }
        public decimal Coefficient { get; set; }
        public string UnitName { get; set; }
        public string FactoryName { get; set; }
   
        
 
    }
}