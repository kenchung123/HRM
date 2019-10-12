using HRM.Model.Entities.Factory;
using HRM.Service.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRM.Model.ViewModel;

namespace HRM.Service.Shared.Factory
{
    public interface IFactoryService:IServiceBase<Model.Entities.Factory.Factory,FactoryViewModels>
    {
       
    }
}