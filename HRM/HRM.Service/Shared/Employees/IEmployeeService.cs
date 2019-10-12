using System;
using System.Threading.Tasks;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel.Employees;
using HRM.Service.Collections;
using HRM.UnitOfWork.Collections;

namespace HRM.Service.Shared.Employees
{
    public interface IEmployeeService : IServiceBase<Employee,EmployeeViewModel>
    {
        EmployeeViewModel Login(string username, string password);
        EmployeeViewModel ChangePassword(Guid id, string oldpass, string newpass);
        EmployeeViewModel ForgotPassword (string email);
        EmployeeViewModel NewPassword(string email,string newpassword);
//        EmployeeViewModel GetManager(EmployeeViewModel employeeViewModel);
        InfomationViewModel AccountInformation(Guid employeeId);
        EmployeeViewModel EditAccountInformation(InfomationViewModel info);
      
        EmployeeViewModel GetManager(Guid id);
        
    }
}