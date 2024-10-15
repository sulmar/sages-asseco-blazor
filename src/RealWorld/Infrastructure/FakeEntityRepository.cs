using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly IDictionary<int, TEntity> _entities;

    public FakeEntityRepository(IEnumerable<TEntity> entities) => _entities = entities.ToDictionary(p => p.Id);
    public void Add(TEntity entity)
    {
        var id = _entities.Max(p => p.Key);

        entity.Id = ++id;

        _entities.Add(entity.Id, entity);
    }

    public TEntity Get(int id) => _entities[id];

    public IEnumerable<TEntity> GetAll() => _entities.Values;
}
