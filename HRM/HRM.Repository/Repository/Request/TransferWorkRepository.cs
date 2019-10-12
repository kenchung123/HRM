using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Request;
using HRM.Repository.Shared.Request;
using HRM.UnitOfWork.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRM.Repository.Repository.Request
{
    public class TransferWorkRepository : Repository<TransferWork>, ITransferWorkRepository
    {
        public TransferWorkRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}