using HRM.Model.Entities;
using HRM.UnitOfWork.Collections;
using HRM.UnitOfWork.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace HRM.Service.Collections
{
    public class ServiceBase<TEntity, TViewModelEntity> : IServiceBase<TEntity, TViewModelEntity>
        where TEntity : class, IEntity where TViewModelEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private ILogger<ServiceBase<TEntity, TViewModelEntity>> _logger;

        public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<ServiceBase<TEntity, TViewModelEntity>> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public virtual TEntity Create(TEntity entity)
        {
            entity.Id = new Guid();
            entity.DateCreated = DateTime.Now;
            _unitOfWork.GetRepository<TEntity>().Insert(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }


        public virtual TEntity MoveToTrash(TEntity entity)
        {
            entity.IsDelete = true;
            _unitOfWork.GetRepository<TEntity>().Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            _unitOfWork.GetRepository<TEntity>().Delete(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }

        public virtual TEntity Get(Guid id)
        {
            var e = _unitOfWork.GetRepository<TEntity>()
                .GetFirstOrDefault(predicate: b => b.Id == id && b.IsDelete == false);
            return e;
        }

        public virtual TEntity Delete(Guid id)
        {
            var e = _unitOfWork.GetRepository<TEntity>().GetFirstOrDefault(predicate: b => b.Id == id);
            if (e != null)
                _unitOfWork.GetRepository<TEntity>().Delete(id);
            _unitOfWork.SaveChanges();
            return e;
        }

        public async Task<object> GetViewModel()
        {
            try
            {
                var entity = await GetAllAsync();
                var data = entity.Items.ToList();
                var entityViewModels = _mapper.Map<List<TViewModelEntity>>(data);
                var result = new PagedList<TViewModelEntity>(source: entityViewModels, pageIndex: entity.PageIndex,
                    pageSize: entity.PageSize, indexFrom: entity.IndexFrom);
//                _logger.LogInformation($"Get success");
                return result;
            }
            catch (Exception e)
            {
//                _logger.LogError($"Get Fail");
                return HttpStatusCode.BadRequest;
            }
        }

        public virtual TViewModelEntity GetViewModel(Guid id)
        {
            try
            {
                var find = Get(id);
                var entity = _mapper.Map<TViewModelEntity>(find);
                _logger.LogInformation($"Get ID Success");
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError($"Get Id Fail");
                throw;
            }
        }

        public virtual TViewModelEntity CreateViewModel(TViewModelEntity viewModelEntity)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(viewModelEntity);
                entity.Id = new Guid();
                entity.DateCreated = DateTime.Now;
                _unitOfWork.GetRepository<TEntity>().Insert(entity);
                _unitOfWork.SaveChanges();
                var tentityViewModel = _mapper.Map<TViewModelEntity>(entity);
                _logger.LogInformation($"Create Success");
                return tentityViewModel;
            }
            catch (Exception e)
            {
                _logger.LogError($"Create Fail");
                throw;
            }
        }

        public virtual TViewModelEntity UpdateViewModel(TViewModelEntity viewModelEntity)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(viewModelEntity);
                entity.LastModified = DateTime.Now;
                _unitOfWork.GetRepository<TEntity>().Update(entity);
                _unitOfWork.SaveChanges();
                var tentityViewModelResult = _mapper.Map<TViewModelEntity>(entity);
                _logger.LogInformation($"Update Success");
                return tentityViewModelResult;
            }
            catch (Exception e)
            {
                _logger.LogError($"Update Fail");
                throw;
            }
        }

        public virtual TViewModelEntity DeleteViewModel(Guid id)
        {
            try
            {
                var entity = Get(id);
                _unitOfWork.GetRepository<TEntity>().Delete(id);
                _unitOfWork.SaveChanges();
                var deleteViewModels = _mapper.Map<TViewModelEntity>(entity);
                _logger.LogInformation($"Delete Success");
                return deleteViewModels;
            }
            catch (Exception e)
            {
                _logger.LogError($"Delete Fail");
                throw;
            }
        }

        public virtual async Task<IPagedList<TEntity>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TEntity>().GetPagedListAsync(predicate: b => b.IsDelete == false);
        }

        public virtual TEntity Update(TEntity entity)
        {
            entity.LastModified = DateTime.Now;
            _unitOfWork.GetRepository<TEntity>().Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }
    }

}