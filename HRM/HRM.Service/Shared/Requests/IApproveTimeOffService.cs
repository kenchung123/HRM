using System;
using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Request;
using HRM.Service.Collections;

namespace HRM.Service.Shared.Requests
{
    public interface IApproveTimeOffService : IServiceBase<ApproveDayOff, ApproveDayOffViewModel>
    {
    }
}