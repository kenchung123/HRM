using HRM.Model.Entities.Request;
using HRM.Repository.Shared.Request;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.Request
{
    public class ChangeShiftRepository : Repository<ChangeShift>,IRepository<ChangeShift>
    {
        public ChangeShiftRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}