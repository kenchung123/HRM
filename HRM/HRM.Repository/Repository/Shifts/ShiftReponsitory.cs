using HRM.Model.Entities.Employees;
using HRM.Model.Entities.Shifts;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.Shifts
{
    public class ShiftReponsitory : Repository<Shift>, IRepository<Shift>
    {
        public ShiftReponsitory(DbContext dbContext) : base(dbContext)
        {
        }
    }
}