using System;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model;
using HRM.Model.Entities.Unit;
using HRM.Model.ViewModel;
using HRM.Model.ViewModel.Unit;
using HRM.Service.Shared.Unit;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
         
        }

        // GET: api/unit
        [HttpGet]
        public async Task<object> Get()
        {
            var units = await _unitService.GetViewModel();
            return units;
        }

        // GET: api/unit/5                 
        [HttpGet("{id}")]
        public UnitViewModels Get(Guid id)
        {
            var unit = _unitService.GetViewModel(id);
            return unit;
        }

        // POST: api/unit
        [HttpPost]
        [ApiValidationFilter]
        public UnitViewModels Post([FromBody] UnitViewModels unit)
        {
            return _unitService.CreateViewModel(unit);
        }

        // PUT: api/unit/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public UnitViewModels Put(Guid id, [FromBody] UnitViewModels unit)
        {
            unit.Id = id;
            return _unitService.UpdateViewModel(unit);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public UnitViewModels Delete(Guid id)
        {
            var c = _unitService.DeleteViewModel(id);
            return c;
        }
    }
}