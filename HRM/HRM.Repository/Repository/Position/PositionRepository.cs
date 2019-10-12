using System;
using HRM.Model;
using HRM.Repository.Shared.Position;
using HRM.UnitOfWork.Repositories;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.Position
{
    public class PositionRepository : Repository<Model.Entities.Position.Position>, IPositionRepository
    {
        private readonly HRMDBContext _context;
        public PositionRepository (HRMDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        
    }
}