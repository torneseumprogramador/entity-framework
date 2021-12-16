using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Entity.Produtos.Application.Commands;
using Entity.Produtos.Domain.Repositories;
using Entity.Produtos.Entidades;
using MediatR;

namespace Entity.Produtos.Application.Handlers
{
    public class FornecedoresCommandHandler : 
        IRequestHandler<AtualizarFornecedorCommand, bool>,
        IRequestHandler<NovoFornecedorCommand, bool>,
        IRequestHandler<RemoverFornecedorCommand, bool>

    {
        private readonly IFornecedoresRepository _fornecedoresRepository;
        public FornecedoresCommandHandler(IFornecedoresRepository fornecedoresRepository)
        {
            _fornecedoresRepository = fornecedoresRepository;
        }

        public async Task<bool> Handle(AtualizarFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = await _fornecedoresRepository.Buscar(request.Id);

            if(fornecedor is null)
            {
                throw new System.Exception("Fornecedor não cadastrado!");
            }

            fornecedor.EnderecoId = request.EnderecoId;
            fornecedor.Nome = request.Nome;
            fornecedor.TipoFornecedor = request.TipoFornecedor;

            _fornecedoresRepository.Atualizar(fornecedor);

            return await PesistirDados();
        }

        public async Task<bool> Handle(NovoFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = new Fornecedor
            {
                Ativo = true,
                DocumentoIdentificacao = request.DocumentoIdentificacao,
                EnderecoId = request.EnderecoId,
                Nome = request.Nome,
                TipoFornecedor = request.TipoFornecedor 
            };

            _fornecedoresRepository.Adicionar(fornecedor);

            return await PesistirDados();
        }

        public async Task<bool> Handle(RemoverFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = await _fornecedoresRepository.Buscar(request.FornecedorId);

            if(fornecedor is null)
            {
                throw new System.Exception("Fornecedor não existe!");
            }

            _fornecedoresRepository.Deletar(fornecedor);

            return await PesistirDados();
        }

        private async Task<bool> PesistirDados() => await _fornecedoresRepository.UnitOfWork.Commit();
    }
}