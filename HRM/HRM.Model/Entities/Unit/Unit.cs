using System;
using System.Collections.Generic;
using HRM.Model.Entities;
using HRM.Model.Entities.Employees;


namespace HRM.Model.Entities.Unit
{
    public class Unit : BaseEntity
    {
        public string Name { get; set; }
        public string CostAccountNumber { get; set;}
        public Guid FactoryId { get; set; }
        public Factory.Factory Factory { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}