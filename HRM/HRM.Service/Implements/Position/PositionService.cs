using AutoMapper;
using HRM.Model;
using HRM.Model.ViewModel.Position;
using HRM.Service.Collections;
using HRM.Service.Implements.Employees;
using HRM.Service.Shared.Position;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.Position
{
    public class PositionService : ServiceBase<Model.Entities.Position.Position, PositionViewModel>, IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HRMDBContext _context;
        private readonly ILogger<PositionService> _logger;

        public PositionService(IUnitOfWork unitOfWork,
            IMapper mapper, HRMDBContext context, ILogger<PositionService> logger) : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
    }
}