using HRM.Model.Entities;
using Microsoft.Extensions.DependencyInjection;

using HRM.Model.Entities.Factory;
using  HRM.Model.Entities.Employees;
using HRM.Model.Entities.Position;
using HRM.Model.Entities.Request;
using HRM.Model.Entities.Shifts;

using HRM.Model.Entities.Unit;
using HRM.Model.ViewModel.Employees;
using  HRM.Repository.Repository;
using HRM.Repository.Repository.Employees;
using HRM.Repository.Repository.EmployeeShift;
using HRM.Repository.Repository.Factory;
using HRM.Repository.Repository.Position;
using HRM.Repository.Repository.Request;
using HRM.Repository.Repository.Shifts;

using HRM.Repository.Repository.Unit;
using  HRM.UnitOfWork.Shared;

namespace  HRM.Repository.Extension
{
  public static class RepositoryCollection
  {
    public static IServiceCollection AddRepositoriesInstance(this IServiceCollection service)
    {
 
      service.AddCustomRepository<ChangeShift, ChangeShiftRepository>();
      service.AddCustomRepository<TransferWork, TransferWorkRepository>();
      service.AddCustomRepository<Employee, EmployeeReponsitory>();
      service.AddCustomRepository<Shift, ShiftReponsitory>();
      service.AddCustomRepository<EmployeeShift, EmployeeShiftRepository>();
      service.AddCustomRepository<TimeOff, TimeOffReponsitory>();
      service.AddCustomRepository<Factory, FactoryRepository>();
      service.AddCustomRepository<Unit, UnitRepository>();
      service.AddCustomRepository<Position, PositionRepository>();
      service.AddCustomRepository<RequestType, RequestTypeRepository>();
      service.AddCustomRepository<ApproveDayOff, ApproveTimeOffRepository>();
//      service.AddCustomRepository<ApproveTransWork, ApproveTransWorkRepository>();
      return service;
    }
  }
}
