using Modelo.Domain.Core.Interfaces.Repositorys;
using Modelo.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }
        public virtual void Add(TEntity obj)
        {
            var obj2 = obj.GetType();
            obj2.GetProperty("Active").SetValue(obj, true);
            obj2.GetProperty("DateInsert").SetValue(obj, DateTime.Now);
            obj2.GetProperty("DateUpdate").SetValue(obj, null);
            obj2.GetProperty("Id").SetValue(obj, null);
            _repository.Add(obj);
        }
        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
        public virtual void Update(TEntity obj)
        {
            var obj2 = obj.GetType();
            obj2.GetProperty("DateUpdate").SetValue(obj, DateTime.Now);
            _repository.Update(obj);
        }
        public virtual void Remove(TEntity obj)
        {
            var obj2 = obj.GetType();
            obj2.GetProperty("DateUpdate").SetValue(obj, DateTime.Now);
            _repository.Remove(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
