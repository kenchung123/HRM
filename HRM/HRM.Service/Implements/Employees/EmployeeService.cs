using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using HRM.Model;
using HRM.Model.Entities.Employees;
using HRM.Model.ViewModel;
using HRM.Model.ViewModel.Employees;
using HRM.Repository.Shared.Employees;
using HRM.Service.Collections;
using HRM.Service.Shared.Employees;
using HRM.UnitOfWork.Collections;
using HRM.UnitOfWork.Shared;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using HRM.Repository.Shared.Employees;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace HRM.Service.Implements.Employees
{
    public class EmployeeService : ServiceBase<Employee, EmployeeViewModel>, IServiceBase<Employee, EmployeeViewModel>,
        IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HRMDBContext _context;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IUnitOfWork unitOfWork,
            IMapper mapper, HRMDBContext context, ILogger<EmployeeService> logger) : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

//        public EmployeeViewModel GetManager(EmployeeViewModel employeeViewModel)
//        {
//            var para = _mapper.Map<Employee>(employeeViewModel);
//            var manager = _context.Employees.Where(para => para.EmployeeName)
//        }
        public EmployeeViewModel Login(string username, string password)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Employee>(true) as IEmployeeReponsotory;
                var user = repo.FindByUserName(username);
                var userView = _mapper.Map<EmployeeViewModel>(user);
                if (user != null && user.Password.Equals(password))
                {
                    return userView;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public EmployeeViewModel ChangePassword(Guid id, string oldpass, string newpass)
        {
            var user = Get(id);
            var userView = _mapper.Map<EmployeeViewModel>(user);
            if (user != null && user.Password.Equals(oldpass))
            {
                userView.Password = newpass;
                try
                {
                    UpdateViewModel(userView);
                    return userView;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message, "Error Change Password");
                }
            }

            return null;
        }

        public EmployeeViewModel ForgotPassword(string email)
        {
            var repo = _unitOfWork.GetRepository<Employee>(true) as IEmployeeReponsotory;
            var emailFind = repo.FindByEmail(email);
           if (emailFind != null)
           {
                try
                {
                    //instantiate a new MimeMessage
                    var message = new MimeMessage();
                    //Setting the To e-mail address
                    message.To.Add(new MailboxAddress("E-mail Recipient Name", email));
                    //Setting the From e-mail address
                    message.From.Add(new MailboxAddress("HRM", "teamwork3s.2019@gmail.com"));
                    //E-mail subject 
                    message.Subject = "NewPassword";
                    //E-mail message body
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = "Link reset password of you is : " + "https://localhost:5001/swagger"
                    };
                   
                    //Configure the e-mail
                    using (var emailClient = new SmtpClient())
                    {
                        emailClient.Connect("smtp.gmail.com", 587, false);
                        emailClient.Authenticate("quocminh123.dt@gmail.com", "6402wanbi");
                        emailClient.Send(message);
                        emailClient.Disconnect(true);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Error ForgotPassword");
                }        
           }

            return null;
        }

        public EmployeeViewModel NewPassword(string email, string newpassword)
        {
            var repo = _unitOfWork.GetRepository<Employee>(true) as IEmployeeReponsotory;
            var emailFind = repo.FindByEmail(email);
            var emailView = _mapper.Map<EmployeeViewModel>(emailFind);
            if(emailFind != null)
            {
                emailView.Password = newpassword;
                try
                {
                    UpdateViewModel(emailView);
                    return emailView;
                }
                catch (Exception e)
                {
                   _logger.LogError(e.Message,"Error Newpassword");
                   
                }
            }

            return null;
        }

        public InfomationViewModel AccountInformation(Guid id)
        {
            var employee = _context.Employees
                .Include(e => e.Position)
                .Include(e => e.Unit)
                .ThenInclude(e => e.Factory)
                .Select(e => new InfomationViewModel()
                {
                    Id = e.Id,
                    UserName = e.UserName,
                    EmployeeName = e.EmployeeName,
                    UnitName = e.Unit.Name,
                    DateOfBirth = e.DateOfBirth,
                    Address = e.Address,
                    Email = e.Email,
                    Phone = e.Phone,
                    HireDay = e.HireDay,
                    PositionName = e.Position.PositionName,
                    BasicSalary = e.BasicSalary,
                    Coefficient = e.Coefficient,
                    FactoryName = e.Unit.Factory.Name
                }).FirstOrDefault(e => e.Id.Equals(id));

            return employee;
        }

        public EmployeeViewModel EditAccountInformation(InfomationViewModel info)
        {
            var employee = GetViewModel(info.Id);

            var editEmployee = new EmployeeViewModel()
            {
                Id = employee.Id,
                Password = employee.Password,
                UserName = employee.UserName,
                EmployeeName = employee.EmployeeName,
                Address = info.Address,
                Email = info.Email,
                Phone = info.Phone,
                DateOfBirth = info.DateOfBirth,
                HireDay = info.HireDay,
                UnitId = employee.UnitId,
                PositionId = employee.PositionId,
                BasicSalary = employee.BasicSalary,
                Coefficient = employee.Coefficient
            };
            try
            {
                UpdateViewModel(editEmployee);
                return editEmployee;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return editEmployee;
        }


        public EmployeeViewModel GetManager(Guid id)
        {
            var employee = Get(id);
            var manager = _unitOfWork.GetRepository<Employee>()
                .GetFirstOrDefault(predicate: e => e.UnitId.Equals(employee.UnitId) && e.IsManager && !e.IsDelete);
            return _mapper.Map<EmployeeViewModel>(manager);
        }
    }
}