using AutoMapper;
using HRM.Model.Entities;
using HRM.Model.Entities.Employees;
using HRM.Model.Entities.Factory;
using HRM.Model.Entities.Position;
using HRM.Model.Entities.Request;
using HRM.Model.Entities.Shifts;
using HRM.Model.Entities.Unit;
using HRM.Model.ViewModel;
using HRM.Model.ViewModel.Employees;
using HRM.Model.ViewModel.Position;
using HRM.Model.ViewModel.Request;
using HRM.Model.ViewModel.Shifts;
using HRM.Model.ViewModel.Unit;

namespace HRM.Model
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EmployeeViewModel, Employee>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(d => d.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.EmployeeName, opt => opt.MapFrom(src => src.EmployeeName))
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.HireDay, opt => opt.MapFrom(src => src.HireDay))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.PositionId, opt => opt.MapFrom(src => src.PositionId))
                .ForMember(d => d.BasicSalary, opt => opt.MapFrom(src => src.BasicSalary))
                .ForMember(d => d.Coefficient, opt => opt.MapFrom(src => src.Coefficient))
                .ForMember(d => d.UnitId, opt => opt.MapFrom(src => src.UnitId))
                .ForMember(d => d.IsManager, opt => opt.MapFrom(src => src.IsManager));

            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(d => d.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.EmployeeName, opt => opt.MapFrom(src => src.EmployeeName))
                .ForMember(d => d.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(d => d.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(d => d.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(d => d.HireDay, opt => opt.MapFrom(src => src.HireDay))
                .ForMember(d => d.PositionId, opt => opt.MapFrom(src => src.PositionId))
                .ForMember(d => d.BasicSalary, opt => opt.MapFrom(src => src.BasicSalary))
                .ForMember(d => d.Coefficient, opt => opt.MapFrom(src => src.Coefficient))
                .ForMember(d => d.UnitId, opt => opt.MapFrom(src => src.UnitId))
                .ForMember(d => d.IsManager, opt => opt.MapFrom(src => src.IsManager));

            CreateMap<Shift, ShiftViewModel>()
                .ForMember(d => d.ShiftName, opt => opt.MapFrom(src => src.ShiftName))
                .ForMember(d => d.Marks, opt => opt.MapFrom(src => src.Marks));

            CreateMap<ShiftViewModel, Shift>()
                .ForMember(d => d.ShiftName, opt => opt.MapFrom(src => src.ShiftName))
                .ForMember(d => d.Marks, opt => opt.MapFrom(src => src.Marks));

            CreateMap<TimeOff, TimeOffViewModel>()
                .ForMember(d => d.SenderId, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(d => d.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.IsAllDay, opt => opt.MapFrom(src => src.IsAllDay))
                .ForMember(d => d.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(d => d.End, opt => opt.MapFrom(src => src.End))
                .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content));

            CreateMap<TimeOffViewModel, TimeOff>()
                .ForMember(d => d.SenderId, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(d => d.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.IsAllDay, opt => opt.MapFrom(src => src.IsAllDay))
                .ForMember(d => d.Start, opt => opt.MapFrom(src => src.Start))
                .ForMember(d => d.End, opt => opt.MapFrom(src => src.End))
                .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content));
            
            CreateMap<FactoryViewModels, Factory>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Factory, FactoryViewModels>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name));
            
            CreateMap<UnitViewModels, Unit>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.CostAccountNumber, opt => opt.MapFrom(src => src.CostAccountNumber))
                .ForMember(d => d.FactoryId, opt => opt.MapFrom(src => src.FactoryId));


            CreateMap<Unit, UnitViewModels>()
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.CostAccountNumber, opt => opt.MapFrom(src => src.CostAccountNumber))
                .ForMember(d => d.FactoryId, opt => opt.MapFrom(src => src.FactoryId));
     CreateMap<ChangeShift, ChangeShiftViewModel>()
                 .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.SenderId, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(d => d.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.FactoryName, opt => opt.MapFrom(src => src.FactoryName))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(src => src.UnitName))
                .ForMember(d => d.NewShift, opt => opt.MapFrom(src => src.NewShift))
                .ForMember(d => d.OldShift, opt => opt.MapFrom(src => src.OldShift))
                .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content));

            CreateMap<ChangeShiftViewModel, ChangeShift>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.SenderId, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(d => d.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.FactoryName, opt => opt.MapFrom(src => src.FactoryName))
                .ForMember(d => d.UnitName, opt => opt.MapFrom(src => src.UnitName))
                .ForMember(d => d.NewShift, opt => opt.MapFrom(src => src.NewShift))
                .ForMember(d => d.OldShift, opt => opt.MapFrom(src => src.OldShift))
                .ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content));

            CreateMap<TransferWorkViewModel, TransferWork>()
                .ForMember(d => d.SendById, opt => opt.MapFrom(src => src.SendById))
                .ForMember(d => d.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(d => d.UnitFrom, opt => opt.MapFrom(src => src.UnitFrom))
                .ForMember(d => d.UnitTo, opt => opt.MapFrom(src => src.UnitTo))
                .ForMember(d => d.Reason, opt => opt.MapFrom(src => src.Reason));


            CreateMap<TransferWork, TransferWorkViewModel>()
                .ForMember(d => d.SendById, opt => opt.MapFrom(src => src.SendById))
                .ForMember(d => d.ReceiverId, opt => opt.MapFrom(src => src.ReceiverId))
                .ForMember(d => d.UnitFrom, opt => opt.MapFrom(src => src.UnitFrom))
                .ForMember(d => d.UnitTo, opt => opt.MapFrom(src => src.UnitTo))
                .ForMember(d => d.Reason, opt => opt.MapFrom(src => src.Reason));

            CreateMap<Position, PositionViewModel>()
                .ForMember(d => d.PositionName, opt => opt.MapFrom(src => src.PositionName))
                .ForMember(d => d.Note, opt => opt.MapFrom(src => src.Note));

            CreateMap<PositionViewModel, Position>()
                .ForMember(d => d.PositionName, opt => opt.MapFrom(src => src.PositionName))
                .ForMember(d => d.Note, opt => opt.MapFrom(src => src.Note));
        }
    }
}