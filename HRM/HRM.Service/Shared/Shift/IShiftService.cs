using System;
using System.Threading.Tasks;
using HRM.Model.ViewModel.Shifts;
using HRM.Service.Collections;

namespace HRM.Service.Shared.Shift
{
    public interface IShiftService : IServiceBase<Model.Entities.Shifts.Shift, ShiftViewModel>
    {
    }
}