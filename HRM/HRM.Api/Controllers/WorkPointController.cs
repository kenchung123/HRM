using System.Collections.Generic;

using HRM.Service.Shared.EmployeeShift;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkPointController : Controller
    {
        private readonly IEmployeeShiftService _employeeShiftService;


        public WorkPointController(IEmployeeShiftService employeeShiftService)
        {
            _employeeShiftService = employeeShiftService;

        }

        [HttpGet]
        [Route("/WorkPointFollowDays")]
        public List<string> WorkPointFollowDays()
        {
            var employees =   _employeeShiftService.GetEmployeeShift();
            return employees;
        }
    }
}