using HRM.Model.Entities.Request;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.Request
{
    public class RequestTypeRepository : Repository<RequestType>, IRepository<RequestType>
    {
        public RequestTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}