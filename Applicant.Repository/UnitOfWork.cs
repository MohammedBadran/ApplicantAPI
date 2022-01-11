﻿
using Applicant.Context;
using Applicant.Repository;
using Applicant.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEWA.SQRC.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Applicant_Context _context;
        private Hashtable _repositories;

        public UnitOfWork(Applicant_Context dbContext)
        {
            _context = dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            //Rollback
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Commit()
        {
           _context.SaveChanges();
        }

    }
}
