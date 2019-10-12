using System.Linq;
using HRM.Model;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel.Employees;
using HRM.Repository.Shared.Employees;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRM.Model;

namespace HRM.Repository.Repository.Employees
{
    public class EmployeeReponsitory : Repository<Employee>, IEmployeeReponsotory
    {
        private readonly HRMDBContext _hrmdbContext;
        public EmployeeReponsitory (HRMDBContext hrmdbContext) : base(hrmdbContext)
        {
            _hrmdbContext = hrmdbContext;
        }
        public Employee FindByUserName(string usename)
        {
            var employee = _hrmdbContext.Employees.FirstOrDefault(e => e.UserName.Equals(usename));
            return employee;
        }

        public Employee FindByEmail(string email)
        {
            var employee = _hrmdbContext.Employees.FirstOrDefault(e => e.Email.Equals(email));
            return employee;
        }
    }
}