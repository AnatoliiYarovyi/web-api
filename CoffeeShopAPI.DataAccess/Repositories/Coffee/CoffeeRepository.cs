using System.Collections.ObjectModel;
using CoffeeShopAPI.DataAccess.Entities;

namespace CoffeeShopAPI.DataAccess.Repositories.Coffee;

public class CoffeeRepository : ICoffeeRepository
{
    private readonly CoffeeShopContext _context;

    public CoffeeRepository(CoffeeShopContext context)
    {
        _context = context;
    }

    public Task<ReadOnlyCollection<CoffeeEntity>> Get() =>
        Task.FromResult(_context.Coffee.ToList().AsReadOnly());

    public Task<CoffeeEntity?> Get(string id) =>
        Task.FromResult(_context.Coffee.FirstOrDefault(e => e.Id == id));

    public Task<ReadOnlyCollection<CoffeeEntity>> Get(Func<CoffeeEntity, bool> predicate)
    {
        return Task.FromResult(_context.Coffee.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(CoffeeEntity entity)
    {
        _context.Coffee.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(CoffeeEntity entity)
    {
        foreach (var e in _context.Coffee)
        {
            if (e.Id == entity.Id)
            {
                e.Name = entity.Name;
                e.Price = entity.Price;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string id)
    {
        var entity = _context.Coffee.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            _context.Coffee.Remove(entity);
        }
        return Task.CompletedTask;
    }
}