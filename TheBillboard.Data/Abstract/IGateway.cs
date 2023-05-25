namespace TheBillboard.Data.Abstract;

using Models;

public interface IGateway<TEntity> where TEntity : Entity
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
    TEntity Insert(TEntity entity);
    TEntity Modify(TEntity entity);
    TEntity Delete(int id);
}