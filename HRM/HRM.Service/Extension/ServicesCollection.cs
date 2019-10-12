﻿using HRM.Model.Entities.Employees;
using HRM.Model.Entities.Factory;
using HRM.Model.Entities.Position;
using Microsoft.Extensions.DependencyInjection;
using HRM.Model.Entities.Request;
using HRM.Model.Entities.Shifts;
using HRM.Service.Collections;
using HRM.Model.Entities.Unit;
using HRM.Model.ViewModel;
using HRM.Model.ViewModel.Employees;
using HRM.Model.ViewModel.Request;
using HRM.Model.ViewModel.Shifts;
using HRM.Service.Implements.Employees;
using HRM.Service.Implements.Factory;
using HRM.Service.Implements.Position;
using HRM.Service.Implements.Requests;
using HRM.Service.Implements.Shift;
using HRM.Service.Implements.Unit;
using HRM.Service.Shared.Employees;
using HRM.Service.Shared.Factory;
using HRM.Service.Shared.Position;
using HRM.Service.Shared.Requests;
using HRM.Service.Shared.Shift;
using HRM.Service.Shared.Unit;


namespace HRM.Service.Extension
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddServicesInstance(this IServiceCollection services)
        {
            services.AddScoped<IServiceBase<Employee, EmployeeViewModel>, EmployeeService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IServiceBase<Shift, ShiftViewModel>, ShiftService>();
            services.AddScoped<IShiftService, ShiftService>();

            services.AddScoped<IServiceBase<TimeOff, TimeOffViewModel>, TimeOffService>();
            services.AddScoped<ITimeOffService, TimeOffService>();
            
            services.AddScoped<IServiceBase<Factory, FactoryViewModels>, FactoryService>();
            services.AddScoped<IFactoryService, FactoryService>();
            
//            services.AddScoped<IServiceBase<Unit, UnitViewModels>, UnitService>();
            services.AddScoped<IUnitService, UnitService>();
            
            services.AddScoped<IServiceBase<ChangeShift, ChangeShiftViewModel>, ChangeShiftService>();
            services.AddScoped<IChangeShiftService, ChangeShiftService>();
            
            services.AddScoped<IServiceBase<TransferWork, TransferWorkViewModel>, TransferWorkService>();
            services.AddScoped<ITransferWorkService, TransferWorkService>();
            
            services.AddScoped<IPositionService, PositionService>();
            
            services.AddScoped<IServiceBase<RequestType, RequestTypeViewModel>, RequestTypeService>();
            services.AddScoped<IRequestTypeService, RequestTypeService>();
            
            services.AddScoped<IServiceBase<ApproveDayOff, ApproveDayOffViewModel>, ApproveTimeOffService>();
            services.AddScoped<IApproveTimeOffService, ApproveTimeOffService>();
            
//            services.AddScoped<IServiceBase<ApproveTransWork, ApproveTransWorkViewModel>, ApproveTransWorkService>();
//            services.AddScoped<IApproveTransWorkService, ApproveTransWorkService>();
            return services;
        }
    }
}
