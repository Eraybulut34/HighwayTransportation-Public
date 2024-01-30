using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;

public interface IBaseProvider<TEntity> where TEntity : IEntity
{
    void Add(TEntity Entity);
    void UpdateAsync(TEntity Entity);
    void Delete(int Id);
    void Delete(TEntity Entity);
    List<TEntity> Add(List<TEntity> entities);
    void UpdateAsync(List<TEntity> entities);
}

public class ProviderBase<TService, TEntity> : IBaseProvider<TEntity>
    where TEntity : IEntity, new()
    where TService : IGenericService<TEntity>
{
    TService _service;
    public ProviderBase(TService service)
    {
        _service = service;
    }

    public void Add(TEntity Entity)
    {
        _service.Add(Entity);
    }

    public List<TEntity> Add(List<TEntity> entities)
    {
        _service.Add(entities);
        return entities;
    }

    public void Delete(int Id)
    {
        _service.Delete(Id);
    }

    public void Delete(TEntity Entity)
    {
        _service.Delete(Entity);
    }






    public void UpdateAsync(TEntity Entity)
    {
        _service.UpdateAsync(Entity);
    }

    public void UpdateAsync(List<TEntity> entities)
    {
        _service.UpdateRangeAsync(entities);
    }
}
