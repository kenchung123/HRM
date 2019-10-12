using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using HRM.Model;
using HRM.Model.ViewModel;

using HRM.Service.Collections;
using HRM.Service.Shared.Factory;
using HRM.UnitOfWork.Collections;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.Factory
{
    public class FactoryService: ServiceBase<Model.Entities.Factory.Factory,FactoryViewModels>, IServiceBase<Model.Entities.Factory.Factory,FactoryViewModels>, IFactoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HRMDBContext _context;
        private readonly ILogger<FactoryService> _logger;

        public FactoryService(IUnitOfWork unitOfWork,
            IMapper mapper, HRMDBContext context, ILogger<FactoryService> logger) : base(unitOfWork, mapper, logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
    }
}