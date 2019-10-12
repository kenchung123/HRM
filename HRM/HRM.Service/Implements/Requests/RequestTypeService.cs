using AutoMapper;
using HRM.Model.Entities.Request;
using HRM.Model.ViewModel.Request;
using HRM.Service.Collections;
using HRM.Service.Shared.Requests;
using HRM.UnitOfWork.Shared;
using Microsoft.Extensions.Logging;

namespace HRM.Service.Implements.Requests
{
    public class RequestTypeService : ServiceBase<RequestType, RequestTypeViewModel>,
        IServiceBase<RequestType, RequestTypeViewModel>, IRequestTypeService
    {
        public RequestTypeService(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<ServiceBase<RequestType, RequestTypeViewModel>> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}