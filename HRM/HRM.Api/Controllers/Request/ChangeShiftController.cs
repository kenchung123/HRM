using System;
using System.Threading.Tasks;
using HRM.Model.ViewModel.Request;
using HRM.Service.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers.Request
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeShiftController : Controller
    {
        
            private readonly IChangeShiftService _changeShiftService;

            public ChangeShiftController(IChangeShiftService changeShiftService)
            {
                _changeShiftService = changeShiftService;
            }


            [HttpGet] 
            public async Task<object> Get()
            {
                var changeShift = await _changeShiftService.GetViewModel();
                return changeShift;
            }


            [HttpGet("{id}")]
            public ChangeShiftViewModel Get(Guid id)
            {
                var changeShift = _changeShiftService.GetViewModel(id);
                return changeShift;
            }


            [HttpPost]
            public async Task<ChangeShiftViewModel> Post([FromBody] ChangeShiftViewModel changeShift)
            {
                return _changeShiftService.CreateViewModel(changeShift);
            }


            [HttpPut("{id}")]
            public ChangeShiftViewModel Put(Guid id, [FromBody] ChangeShiftViewModel changeShift)
            {
                changeShift.Id = id;
                return _changeShiftService.UpdateViewModel(changeShift);
            }


            [HttpDelete("{id}")]
            public ChangeShiftViewModel Delete(Guid id)
            {
                var c = _changeShiftService.DeleteViewModel(id);
                return c;
            }
        }
    }
