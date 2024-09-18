using MtgPodium.Infrastructure;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id) 
        => await _entities.FindAsync(id) ?? throw new KeyNotFoundException();
    
    public async Task<IEnumerable<T>> GetAllAsync() 
        => await _entities.ToListAsync();
    
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) 
        => await _entities.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity) 
        => await _entities.AddAsync(entity);

    public void Update(T entity) => _entities.Update(entity);

    public void Remove(T entity) => _entities.Remove(entity);
}