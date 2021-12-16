using System.Threading.Tasks;

namespace Entity.Pedidos.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task<bool> Commit();
    }
}