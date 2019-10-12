using HRM.Model.Entities.Request;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.Request
{
    public class ApproveTimeOffRepository : Repository<ApproveDayOff>, IRepository<ApproveDayOff>
    {
        public ApproveTimeOffRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}