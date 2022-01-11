using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        #region Create
        void Add(T entity);
        void AddByEntityType(T entity);
        void AddByEntityType(string lookupName,T entity,object value);
        void UpdateByEntityType(T entity);
        int DeleteByEntityType(T entity);
        void AddRange(IEnumerable<T> entities);
        #endregion
        #region Edit
        void Update(T entity);
        #endregion
        #region Delete
        T Delete(object id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        #endregion
        #region Get
        T GetEntityById(object id);

        T GetEntityById(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true);

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                             bool disableTracking = true,
                             int? skip = null, int? take = null);


        IEnumerable GetAllByEntityType(string lookupName);
        #endregion
        
    }
}
