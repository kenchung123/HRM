using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRM.Model;
using HRM.Model.Entities.Employees;
using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Employees;
using HRM.Model.ViewModel.Request;
using HRM.Service.Collections;
using HRM.Service.Shared.Employees;
using HRM.Service.Shared.Requests;
using HRM.UnitOfWork.Collections;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace HRM.Service.Implements.Requests
{
    public class TimeOffService : ServiceBase<TimeOff, TimeOffViewModel>, ITimeOffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TimeOffService> _logger;
        private readonly HRMDBContext _context;
        private readonly IEmployeeService _employeeService;

        public TimeOffService(IUnitOfWork unitOfWork,
            IMapper mapper, ILogger<TimeOffService> logger, HRMDBContext context, IEmployeeService employeeService) :
            base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _employeeService = employeeService;
        }

        public List<TimeOffViewModel> GetInbox(Guid id)
        {
            var employee = _employeeService.Get(id);
            var listRequest = _context.TimeOffs.Where(r => r.ReceiverId.Equals(employee.Id)).ToList();
            var result = _mapper.Map<List<TimeOffViewModel>>(listRequest);
            return result;
        }
        
        public TimeOffViewModel CreateRequest(Guid EmployeeId, TimeOffViewModel timeOffViewModel)
        {
            var toEmployee = _employeeService.GetManager(EmployeeId);

            var timeOff = _mapper.Map<TimeOff>(timeOffViewModel);
            var newRequest = new TimeOff()
            {
                SenderId = EmployeeId,
                ReceiverId = toEmployee.Id,
                Title = timeOff.Title,
                IsAllDay = timeOff.IsAllDay,
                Start = timeOff.Start,
                End = timeOff.End,
                Content = timeOff.Content
            };
            _unitOfWork.GetRepository<TimeOff>().Insert(newRequest);
            _unitOfWork.SaveChanges();
            var result = _mapper.Map<TimeOffViewModel>(newRequest);
            return result;
        }
    }
}