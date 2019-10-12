using System;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model.ViewModel.Shifts;
using HRM.Service.Shared.Shift;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : Controller
    {
        private readonly IShiftService _shiftService;
       
        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }
        
        // GET: api/shift
        [HttpGet]          
        public async Task<object> Get()
        {
            var shift = await _shiftService.GetViewModel();
            return shift;
        }

        // GET: api/shift/5                 
        [HttpGet("{id}")]
        public ShiftViewModel Get(Guid id)
        {
            var shift = _shiftService.GetViewModel(id);
            return shift;
        }

        // POST: api/shift
        [HttpPost]
        [ApiValidationFilter]
        public async Task<ShiftViewModel> Post([FromBody] ShiftViewModel shift)
        {
            return _shiftService.CreateViewModel(shift);
        }

        // PUT: api/shift/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public ShiftViewModel Put(Guid id, [FromBody] ShiftViewModel shift)
        {
            shift.Id = id;
            return _shiftService.UpdateViewModel(shift);
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public ShiftViewModel Delete(Guid id)
        {
            var c = _shiftService.DeleteViewModel(id);
            return c;
        }
    }
}