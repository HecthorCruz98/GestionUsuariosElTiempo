using Application.Contracts.Persistence;
using Domain.Common;
using Infraestructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly ElTiempoDbContext _context;


        public UnitOfWork(ElTiempoDbContext context)
        {
            _context = context;
        }

        public ElTiempoDbContext DbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (_repositories == null)
                _repositories = new Hashtable();
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repository);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
