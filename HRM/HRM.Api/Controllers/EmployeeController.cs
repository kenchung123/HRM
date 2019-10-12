using System;
using System.Threading.Tasks;
using AutoMapper;
using HRM.Filters;
using HRM.Model;
using HRM.Model.Entities.Employees;

using HRM.Model.ViewModel.Employees;
using HRM.Service.Shared.Employees;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            
        }

        // GET: api/employee
        [HttpGet]
        public async Task<object> Get()
        {
            var employees = await _employeeService.GetViewModel();
            return employees;
        }

        // GET: api/employee/5                 
        [HttpGet("{id}")]
        public EmployeeViewModel Get(Guid id)
        {
            var employee = _employeeService.GetViewModel(id);
            return employee;
        }

        // POST: api/employee
        [HttpPost]
        [ApiValidationFilter]
        public EmployeeViewModel Post([FromBody] EmployeeViewModel employee)
        {
            return _employeeService.CreateViewModel(employee);
        }

        // PUT: api/employee/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public EmployeeViewModel Put(Guid id, [FromBody] EmployeeViewModel employee)
        {
            employee.Id = id;
            return _employeeService.UpdateViewModel(employee);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public EmployeeViewModel Delete(Guid id)
        {
            var c = _employeeService.DeleteViewModel(id);
            return c;
        }
    }
}