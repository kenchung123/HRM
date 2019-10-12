using HRM.Model.Entities.Employees;

namespace HRM.Repository.Shared.Employees
{
    public interface IEmployeeReponsotory 
    {
        Employee FindByUserName(string usename);
        Employee FindByEmail(string email);
    }
}