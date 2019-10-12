using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRM.Model;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel;
using HRM.Model.ViewModel.Unit;
using HRM.Service.Collections;
using HRM.Service.Shared.Employees;
using HRM.Service.Shared.Unit;
using HRM.UnitOfWork.Collections;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.Unit
{
    public class UnitService : ServiceBase<Model.Entities.Unit.Unit, UnitViewModels>,
        IServiceBase<Model.Entities.Unit.Unit, UnitViewModels>, IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HRMDBContext _context;
        private readonly ILogger<UnitService> _logger;
        private readonly IEmployeeService _employeeService;

        public UnitService(IUnitOfWork unitOfWork,
            IMapper mapper, HRMDBContext context, ILogger<UnitService> logger, IEmployeeService employeeService) : base(
            unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _logger = logger;
            _employeeService = employeeService;
        }

        public UnitViewModels GetUnitId(Guid id)
        {
            var getEmployeeUnit = _employeeService.Get(id);
            var findUnitId = _unitOfWork.GetRepository<Model.Entities.Unit.Unit>()
                .GetFirstOrDefault(predicate: u => u.Id.Equals(getEmployeeUnit.UnitId));
            return _mapper.Map<UnitViewModels>(findUnitId);
        }

    }
}