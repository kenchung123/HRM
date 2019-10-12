using HRM.Model.Entities.Unit;
using HRM.Service.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRM.Model.ViewModel;
using HRM.Model.ViewModel.Unit;

namespace HRM.Service.Shared.Unit
{
    public interface IUnitService:IServiceBase<Model.Entities.Unit.Unit,UnitViewModels>
    {
        UnitViewModels GetUnitId(Guid id);
    }
}