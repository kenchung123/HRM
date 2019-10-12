using System;
using System.Threading.Tasks;
using HRM.Filters;
using HRM.Model;
using HRM.Model.Entities.Factory;
using HRM.Model.ViewModel;
using HRM.Service.Shared.Factory;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {

        private readonly IFactoryService _factoryService;

        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
           
        }

        // GET: api/factory
        [HttpGet]
        public async Task<object> Get()
        {
            var factories= await _factoryService.GetViewModel();
            return factories;
        }

        // GET: api/factory/5                 
        [HttpGet("{id}")]
        public FactoryViewModels Get(Guid id)
        {
            var factory = _factoryService.GetViewModel(id);
            return factory;
        }

        // POST: api/factory
        [HttpPost]
        [ApiValidationFilter]
        public FactoryViewModels Post([FromBody] FactoryViewModels factory)
        {
            return _factoryService.CreateViewModel(factory);
        }

        // PUT: api/factory/5
        [HttpPut("{id}")]
        [ApiValidationFilter]
        public FactoryViewModels Put(Guid id, [FromBody] FactoryViewModels factory)
        {
            factory.Id = id;
            return _factoryService.UpdateViewModel(factory);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiValidationFilter]
        public FactoryViewModels Delete(Guid id)
        {
            var c = _factoryService.DeleteViewModel(id);
            return c;
        }
    }

    }
