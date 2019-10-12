using System;
using System.Net;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel.Employees;
using HRM.Service.Shared.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IEmployeeService _employeeService;


        public LoginController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _employeeService.Login(username, password);
            if (user == null)
            {
                return StatusCode((int) HttpStatusCode.BadRequest, "Invalid username /or password");
            }

            return Ok("Sucess !!!");
        }

        [Route("api/change-password")]
        [HttpPut]
        public async Task<ActionResult> ChangePassword(Guid id, string oldpassword, string newpassword)
        {
            var user = _employeeService.ChangePassword(id, oldpassword, newpassword);
            if (user == null)
            {
                
                return StatusCode((int) HttpStatusCode.BadRequest, "Invalid username and/or oldpassword");
            }

            return Ok("Sucess !!!");
        }

        [HttpPost]
        [Route("forgot-password")]
        [ApiValidationFilter]
        public  async Task<ActionResult> ForgotPassword(string email)
        {
            var user = _employeeService.ForgotPassword(email);
            return Ok("Sucess !!!");

        }

        [HttpPut]
        [Route("newpassword")]
        public async Task<ActionResult> NewPassword(string email, string newpassword)
        {
            var password = _employeeService.NewPassword(email, newpassword);
            return Ok("Sucess !!!");
        }
    }
}