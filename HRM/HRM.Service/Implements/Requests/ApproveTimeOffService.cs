using System;
using AutoMapper;
using HRM.Model;
using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Request;
using HRM.Service.Collections;
using HRM.Service.Shared.Employees;
using HRM.Service.Shared.Requests;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.Requests
{
    public class ApproveTimeOffService : ServiceBase<ApproveDayOff, ApproveDayOffViewModel>, IApproveTimeOffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ApproveTimeOffService> _logger;
        private readonly ITimeOffService _timeOffService;

        public ApproveTimeOffService(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<ApproveTimeOffService> logger) : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
 
    }
}