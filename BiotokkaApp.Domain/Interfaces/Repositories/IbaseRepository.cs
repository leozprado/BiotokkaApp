using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Repositories
{
    public interface IbaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity? GetById(int id);
        List<TEntity> GetAll();
    }
}
