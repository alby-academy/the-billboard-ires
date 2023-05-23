namespace TheBillboard.MVC.Abstract;

using Models;

public interface IGateway<out TEntity> where TEntity : Entity
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int id);
}