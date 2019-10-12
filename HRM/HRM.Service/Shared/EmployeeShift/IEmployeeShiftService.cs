using System.Collections.Generic;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel;
using HRM.Service.Collections;

namespace HRM.Service.Shared.EmployeeShift
{
    public interface IEmployeeShiftService: IServiceBase<Model.Entities.EmployeeShift, EmployeeShiftViewModel>
    {
        List<string> GetEmployeeShift();
    }
}