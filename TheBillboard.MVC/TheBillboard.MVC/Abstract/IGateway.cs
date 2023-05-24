namespace TheBillboard.MVC.Abstract;

using Models;

public interface IGateway<TEntity> where TEntity : Entity
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
    void Insert(TEntity entity);
    void Modify(TEntity entity);
    void Delete(int id);
}