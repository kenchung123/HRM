using System;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model.ViewModel.Position;
using HRM.Model.ViewModel.Shifts;
using HRM.Service.Shared.Position;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

// GET: api/Position
        [HttpGet] 
        public async Task<object> Get()
        {
            var position = await _positionService.GetViewModel();
            return position;
        }

// GET: api/Position/5 
        [HttpGet("{id}")]
        public PositionViewModel Get(Guid id)
        {
            var position = _positionService.GetViewModel(id);
            return position;
        }

// POST: api/Position
        [HttpPost]
        [ApiValidationFilter]
        public async Task<PositionViewModel> Post([FromBody] PositionViewModel position)
        {
            return _positionService.CreateViewModel(position);
        }

// PUT: api/Position/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public PositionViewModel Put(Guid id, [FromBody] PositionViewModel position)
        {
            position.Id = id;
            return _positionService.UpdateViewModel(position);

        }

// DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public PositionViewModel Delete(Guid id)
        {
            var c = _positionService.DeleteViewModel(id);
            return c;
        }
    }
}