using System;
using System.Collections.Generic;
using System.Text;
namespace HRM.Repository.Shared.Unit
{
    public interface IUnitRepository
    {
        Model.Entities.Unit.Unit FindById(Guid id);
    }
}