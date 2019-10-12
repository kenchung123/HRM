using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel;
using HRM.Model.ViewModel.Employees;
using HRM.Service.Shared.Employees;
using HRM.Service.Shared.EmployeeShift;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftController : Controller
    {
        private readonly IEmployeeShiftService _employeeShiftService;


        public EmployeeShiftController(IEmployeeShiftService employeeShiftService, HRMDBContext context)
        {
            _employeeShiftService = employeeShiftService;

        }

//        // GET: api/employeeShift
//        [HttpGet]
//        public async Task<object> Get()
//        {
//            var employeeShift = await _employeeShiftService.GetViewModel();
//            return employeeShift;
//        }

        // GET: api/employeeShift/5                 
        [HttpGet("{id}")]
        public EmployeeShiftViewModel Get(Guid id)
        {
            var employeeShift = _employeeShiftService.GetViewModel(id);
            return employeeShift;
        }

        // POST: api/employeeShift
        [HttpPost]
        [ApiValidationFilter]
        public EmployeeShiftViewModel Post([FromBody] EmployeeShiftViewModel employeeShift)
        {
            return _employeeShiftService.CreateViewModel(employeeShift);
        }

        // PUT: api/employeeShift/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public EmployeeShiftViewModel Put(Guid id, [FromBody] EmployeeShiftViewModel employeeShift)
        {
            employeeShift.Id = id;
            return _employeeShiftService.UpdateViewModel(employeeShift);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public EmployeeShiftViewModel Delete(Guid id)
        {
            var c = _employeeShiftService.DeleteViewModel(id);
            return c;
        }

     
    }
}