using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRM.Model.ViewModel.Request;
using HRM.Service.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers.Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeOffController : Controller
    {
        private readonly ITimeOffService _timeOffService;

        public TimeOffController(ITimeOffService timeOffService)
        {
            _timeOffService = timeOffService;
        }

        // GET: api/timeOffs
        [HttpGet]
        public async Task<object> Get()
        {
            var timeOffs = await _timeOffService.GetViewModel();
            return timeOffs;
        }

        // GET: api/timeOffs/5                 
        [HttpGet("{id}")]
        public TimeOffViewModel Get(Guid id)
        {
            var timeOff = _timeOffService.GetViewModel(id);
            return timeOff;
        }
        
        // GET: api/timeOffs/5                 
        [HttpGet]
        [Route("/inbox/{id}")]
        public List<TimeOffViewModel> Inbox(Guid id)
        {
            var timeOff = _timeOffService.GetInbox(id);
            return timeOff;
        }

        // POST: api/timeOff
        [HttpPost]
        public async Task<TimeOffViewModel> Post(Guid EmployeeId, [FromBody] TimeOffViewModel timeOff)
        {
            return _timeOffService.CreateRequest(EmployeeId, timeOff);
        }

        // PUT: api/timeOff/5
        [HttpPut("{id}")]
        public TimeOffViewModel Put(Guid id, [FromBody] TimeOffViewModel timeOff)
        {
            timeOff.Id = id;
            return _timeOffService.UpdateViewModel(timeOff);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public TimeOffViewModel Delete(Guid id)
        {
            var c = _timeOffService.DeleteViewModel(id);
            return c;
        }
    }
}