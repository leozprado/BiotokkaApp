using BiotokkaApp.Domain.Interfaces.Repositories;
using BiotokkaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiotokkaApp.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IbaseRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }

        public TEntity? GetById(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }
        }
    }
}