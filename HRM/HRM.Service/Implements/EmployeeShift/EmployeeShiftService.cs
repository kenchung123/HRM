using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HRM.Model;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel;
using HRM.Service.Collections;
using HRM.Service.Implements.Employees;
using HRM.Service.Shared.Employees;
using HRM.Service.Shared.EmployeeShift;
using HRM.UnitOfWork.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.EmployeeShift
{
    public class EmployeeShiftService:ServiceBase<Model.Entities.EmployeeShift, EmployeeShiftViewModel>, 
        IServiceBase<Model.Entities.EmployeeShift, EmployeeShiftViewModel>,
        IEmployeeShiftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HRMDBContext _context;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeShiftService(IUnitOfWork unitOfWork,
            IMapper mapper, HRMDBContext context, ILogger<EmployeeShiftService> logger) : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public List<string> GetEmployeeShift()
        {
            
            DateTime now = DateTime.Now;
            if (now.Hour < 12)
            {
                var employee = _context.EmployeeShifts
                    .Include(e => e.Employees)
                    .Include(e => e.Shifts)
                    .Where(e => e.Shifts.ShiftName == "Shift 1")
                    .Select(e => e.Employees.EmployeeName)
                    .ToList();
                return employee;
            }

            else if (now.Hour > 12 && now.Hour < 17)
            {
                var employee = _context.EmployeeShifts
                    .Include(e => e.Employees)
                    .Include(e => e.Shifts)
                    .Where(e => e.Shifts.ShiftName == "Shift 2")
                    .Select(e => e.Employees.EmployeeName).ToList();
                return employee;
            }
            else
            {
                var employee = _context.EmployeeShifts
                    .Include(e => e.Employees)
                    .Include(e => e.Shifts)
                    .Where(e => e.Shifts.ShiftName == "Shift 3")
                    .Select(e => e.Employees.EmployeeName).ToList();
                return employee;
            }

        }
    }
}