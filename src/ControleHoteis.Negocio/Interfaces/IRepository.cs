using ControleHoteis.Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControleHoteis.Negocio.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {

        Task Adicionar(TEntity entity);
        Task<TEntity> ListarPorId(Guid id);
        Task<List<TEntity>> ListarTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
