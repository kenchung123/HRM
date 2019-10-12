using System;
using HRM.UnitOfWork.Shared;
using HRM.Model;
using HRM.Model.Entities.Factory;
using HRM.Repository.Shared.Factory;
using HRM.UnitOfWork.Repositories;

namespace HRM.Repository.Repository.Factory
{
    public class FactoryRepository:Repository<Model.Entities.Factory.Factory>,IFactoryRepository
    
    {
        private readonly HRMDBContext _context;
        public FactoryRepository(HRMDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


        public Model.Entities.Factory.Factory FindById(Guid id)
        {
            return _context.Factories.Find(id);
        }
    }
}