using System.Threading.Tasks;

namespace Entity.Clientes.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}