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
    public class RequestTypeController : Controller
    {
        private readonly IRequestTypeService _requestTypeService;
        private readonly HRMDBContext _context;

        public RequestTypeController(IRequestTypeService requestTypeService, HRMDBContext context)
        {
            _requestTypeService = requestTypeService;
            _context = context;
        }

        // GET: api/requestType
        [HttpGet]
        public async Task<object> Get()
        {
            var requestType = await _requestTypeService.GetViewModel();
            return requestType;
        }

        // GET: api/requestType/5                 
        [HttpGet("{id}")]
        public RequestTypeViewModel Get(Guid id)
        {
            var requestType = _requestTypeService.GetViewModel(id);
            return requestType;
        }

        // POST: api/requestType
        [HttpPost]
        [ApiValidationFilter]
        public RequestTypeViewModel Post([FromBody] RequestTypeViewModel requestType)
        {
            return _requestTypeService.CreateViewModel(requestType);
        }

        // PUT: api/requestType/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public RequestTypeViewModel Put(Guid id, [FromBody] RequestTypeViewModel requestType)
        {
            requestType.Id = id;
            return _requestTypeService.UpdateViewModel(requestType);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public RequestTypeViewModel Delete(Guid id)
        {
            var c = _requestTypeService.DeleteViewModel(id);
            return c;
        }
    }
}