using HRM.Model.Entities;
using HRM.UnitOfWork.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Service.Collections
{
   public interface IServiceBase<TEntity, TViewModelEntity> where TEntity : class , IEntity where TViewModelEntity : class  
    {
        Task<IPagedList<TEntity>> GetAllAsync();        
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        TEntity MoveToTrash(TEntity entity);
        TEntity Get(Guid id);
        TEntity Delete(Guid id);
        
        Task<object> GetViewModel();
        TViewModelEntity GetViewModel(Guid id);
        TViewModelEntity CreateViewModel(TViewModelEntity viewModelEntity);
        TViewModelEntity UpdateViewModel (TViewModelEntity viewModelEntity);
        TViewModelEntity DeleteViewModel (Guid id);
    }
}
