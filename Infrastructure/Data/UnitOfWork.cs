using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly StoreContext _context;
    private Hashtable _repositories;

    public UnitOfWork(StoreContext context)
    {
      _context = context;
    }

    public async Task<int> Complete()
    {
      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
      // Check if hashtable is already created 
      if (_repositories == null) _repositories = new Hashtable();

      // Get the type of the name of the TEntity passed through (i.e., Product)
      var type = typeof(TEntity).Name;

      // Check if hashtable already have this type
      if (!_repositories.ContainsKey(type))
      {
        // If not --> Create repo of this type
        var repositoryType = typeof(GenericRepository<>);
        // Create an instance of the repo & pass in the context from UoW
        var repositoryInstance = Activator.CreateInstance(
          repositoryType.MakeGenericType(typeof(TEntity)), _context
        );

        // Add the instance to the hashtable
        _repositories.Add(type, repositoryInstance);

      }

      return (IGenericRepository<TEntity>) _repositories[type];
    }
  }
}