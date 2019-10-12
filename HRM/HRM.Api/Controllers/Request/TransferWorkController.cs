using System;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model;
using HRM.Model.ViewModel.Request;
using HRM.Service.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferWorkController : Controller
    {
        private readonly ITransferWorkService _transferWorkService;

        public TransferWorkController(ITransferWorkService transferWorkService)
        {
            _transferWorkService = transferWorkService;

        }

        // GET: api/transferWork
        [HttpGet]
        public async Task<object> Get()
        {
            var transferWorks = await _transferWorkService.GetViewModel();
            return transferWorks;
        }

        // GET: api/transferWork/5 
        [HttpGet("{id}")]
        public TransferWorkViewModel Get(Guid id)
        {
            var transferWork = _transferWorkService.GetViewModel(id);
            return transferWork;
        }

        // POST: api/transferWork
        [HttpPost]
        [ApiValidationFilter]
        public TransferWorkViewModel Post(Guid id, [FromBody] TransferWorkViewModel transferWork)
        {
            return _transferWorkService.CreateRequest(id, transferWork);
        }

        // PUT: api/transferWork/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public TransferWorkViewModel Put(Guid id, [FromBody] TransferWorkViewModel transferWork)
        {
            transferWork.Id = id;
            return _transferWorkService.UpdateViewModel(transferWork);
        }

        // DELETE: api/transferWork/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public TransferWorkViewModel Delete(Guid id)
        {
            var c = _transferWorkService.DeleteViewModel(id);
            return c;
        }
    }
}