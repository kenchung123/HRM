using System;
using HRM.Filters;
using HRM.Model.ViewModel.Employees;
using HRM.Service.Shared.Employees;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public InformationController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("/AccountInformation")]
        public InfomationViewModel AccountInformation(Guid id)
        {
            var info = _employeeService.AccountInformation(id);
            return info;
        }
        [HttpPut]
        [Route("/EditAccountInformation")]
        [ApiValidationFilter]
        public EmployeeViewModel EditAccountInformation([FromBody] InfomationViewModel info)
       
        {
            var info1 = _employeeService.EditAccountInformation(info);
            return info1;
        }
    }
}