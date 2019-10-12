using HRM.Model.Entities.Request;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.Request
{
    public class TimeOffReponsitory : Repository<TimeOff>, IRepository<TimeOff>
    {
        public TimeOffReponsitory(DbContext dbContext) : base(dbContext)
        {
        }
    }
}