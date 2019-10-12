using System;
using HRM.Model;
using HRM.Repository.Shared.Unit;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;

namespace HRM.Repository.Repository.Unit
{
    public class UnitRepository:Repository<Model.Entities.Unit.Unit>,IUnitRepository
    {
        private readonly HRMDBContext _context;
        public UnitRepository(HRMDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public Model.Entities.Unit.Unit FindById(Guid id)
        {
            var unit = _context.Units.Find(id);
            return unit;
        }
    }
}