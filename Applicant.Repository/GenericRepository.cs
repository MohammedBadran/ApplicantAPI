using Applicant.Context;
using Applicant.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Applicant_Context _context;
        private readonly DbSet<T> _table;

        public GenericRepository(Applicant_Context dbContext)
        {
            _context = dbContext;
            _table = dbContext.Set<T>();
        }

        #region Add Entity

        public void Add(T entity)
        {
            _table.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
        }
        #endregion

        #region Update Entity
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        #endregion

        #region Delete Entity
        public T Delete(object id)
        {
            T entity = _table.Find(id);
            Delete(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _table.RemoveRange(entities);
        }
        #endregion

        #region Get Entity

        public T GetEntityById(object id)
        {
            return _table.Find(id);
        }
        public T GetEntityById(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true)
        {
            var query = _table.Where(predicate);

            if (include != null)
                query = include(query);

            if (disableTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                             bool disableTracking = true,
                             int? skip = null, int? take = null)
        {
            IQueryable<T> query = _table;

            if (filter != null)
                query = query.Where(filter);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            if (disableTracking)
                query = query.AsNoTracking();

            //if (select != null)
            //    query = select(query);

            return query.ToList();
        }

        public void AddByEntityType(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddByEntityType(string lookupName, T entity, object value)
        {
            throw new NotImplementedException();
        }

        public void UpdateByEntityType(T entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteByEntityType(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetAllByEntityType(string lookupName)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
