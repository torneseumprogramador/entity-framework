namespace Entity.Shared.Mensagens
{
    public interface INotificacaoHandler<T> where T : INotificacao
    {
        public void Handle(T evento);
    }
}