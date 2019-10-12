using System;
using AutoMapper;
using HRM.Model;
using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Request;
using HRM.Service.Collections;
using HRM.Service.Shared.Employees;
using HRM.Service.Shared.Factory;
using HRM.Service.Shared.Requests;
using HRM.Service.Shared.Unit;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.Requests
{
    public class TransferWorkService : ServiceBase<TransferWork, TransferWorkViewModel>, ITransferWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TransferWorkService> _logger;
        private readonly HRMDBContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly IUnitService _unitService;
        private readonly IFactoryService _factoryService;

        public TransferWorkService(IUnitOfWork unitOfWork,
            IMapper mapper, ILogger<TransferWorkService> logger, HRMDBContext context,
            IEmployeeService employeeService, IUnitService unitService, IFactoryService factoryService) :
            base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _employeeService = employeeService;
            _unitService = unitService;
            _factoryService = factoryService;
        }

        public TransferWorkViewModel CreateRequest(Guid id, TransferWorkViewModel transferWorkViewModel)
        {
            var toEmployee = _employeeService.GetManager(id);
            var unit = _unitService.GetUnitId(id);

            var transfer = _mapper.Map<TransferWork>(transferWorkViewModel);
            var create = new TransferWork()
            {
                SendById = id,
                ReceiverId = toEmployee.Id,
                UnitFrom = unit.Id,
                UnitTo = transfer.UnitTo,
                Reason = transfer.Reason
            };
            _unitOfWork.GetRepository<TransferWork>().Insert(create);
            _unitOfWork.SaveChanges();
            var result = _mapper.Map<TransferWorkViewModel>(create);
            return result;
        }
    }
}