using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Clientes.Domain.Entidades;

namespace Entity.Clientes.Domain.Repositories
{
    public interface IClienteRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get;}
        Task<IEnumerable<Cliente>> BuscarTodos();
        Task<IEnumerable<Cliente>> BuscarTodosComEndereco();
        Task<Cliente> BuscarClienteEndereco(int id);
        Task<IEnumerable<Endereco>> BuscarEnderecos();
        void Deletar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Adicionar(Cliente cliente);
        void AtualizarEndereco(Endereco endereco);
        Task<bool> ClienteExiste(int id);
    }
}