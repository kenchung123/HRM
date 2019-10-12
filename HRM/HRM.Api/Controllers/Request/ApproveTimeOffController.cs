using System;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model;
using HRM.Model.ViewModel.Request;
using HRM.Service.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers.Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveTimeOffController : Controller
    {
        private readonly IApproveTimeOffService _approveTimeOffService;
        private readonly HRMDBContext _context;

        public ApproveTimeOffController(IApproveTimeOffService approveTimeOffService, HRMDBContext context)
        {
            _approveTimeOffService = approveTimeOffService;
            _context = context;
        }

        // GET: api/approve
        [HttpGet]
        public async Task<object> Get()
        {
            var approve = await _approveTimeOffService.GetViewModel();
            return approve;
        }

        // GET: api/approve/5                 
        [HttpGet("{id}")]
        public ApproveDayOffViewModel Get(Guid id)
        {
            var approve = _approveTimeOffService.GetViewModel(id);
            return approve;
        }

        // POST: api/approve
        [HttpPost]
        [ApiValidationFilter]
        public ApproveDayOffViewModel Post([FromBody] ApproveDayOffViewModel approve)
        {
            return _approveTimeOffService.CreateViewModel(approve);
        }

        // PUT: api/approve/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public ApproveDayOffViewModel Put(Guid id, [FromBody] ApproveDayOffViewModel approve)
        {
            approve.Id = id;
            return _approveTimeOffService.UpdateViewModel(approve);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public ApproveDayOffViewModel Delete(Guid id)
        {
            var c = _approveTimeOffService.DeleteViewModel(id);
            return c;
        }
    }
}