using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRM.Model.ViewModel.Shifts;
using HRM.Service.Collections;
using HRM.Service.Shared.Shift;
using HRM.UnitOfWork.Collections;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace HRM.Service.Implements.Shift
{
    public class ShiftService : ServiceBase<Model.Entities.Shifts.Shift, ShiftViewModel>, IServiceBase<Model.Entities.Shifts.Shift, ShiftViewModel>, IShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ShiftService> _logger;

        public ShiftService(IUnitOfWork unitOfWork,
            IMapper mapper, ILogger<ShiftService> logger) : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
    }
}