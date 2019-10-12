using AutoMapper;
using HRM.Model;
using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Request;
using HRM.Service.Collections;
using HRM.Service.Shared.Requests;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.Requests
{
    public class ChangeShiftService : ServiceBase<ChangeShift,ChangeShiftViewModel>,IChangeShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HRMDBContext _context;
        private readonly ILogger<ChangeShiftService> _logger;

        public ChangeShiftService(IUnitOfWork unitOfWork,
            IMapper mapper, HRMDBContext context, ILogger<ChangeShiftService> logger) : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
    }
}