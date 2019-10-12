using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.EmployeeShift
{
    public class EmployeeShiftRepository:Repository<Model.Entities.EmployeeShift>, IRepository<Model.Entities.EmployeeShift>
    {
        public EmployeeShiftRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}