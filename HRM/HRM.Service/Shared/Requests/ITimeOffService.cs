using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Request;
using HRM.Service.Collections;

namespace HRM.Service.Shared.Requests
{
    public interface ITimeOffService : IServiceBase<TimeOff, TimeOffViewModel>
    {
        TimeOffViewModel CreateRequest(Guid EmployeeId, TimeOffViewModel timeOffViewModel);
        List<TimeOffViewModel> GetInbox(Guid id);
    }
}