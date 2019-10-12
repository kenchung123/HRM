using System;
using System.Collections.Generic;
using System.Text;
namespace HRM.Repository.Shared.Factory
{
    public interface IFactoryRepository
    {
        Model.Entities.Factory.Factory FindById(Guid id);
    }
}