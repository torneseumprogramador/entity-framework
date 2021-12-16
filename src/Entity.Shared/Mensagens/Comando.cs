using System;

namespace Entity.Shared.Mensagens
{
    public abstract class Comando : IRequisicao
    {
        public DateTime TimeStamp { get; set;}

        protected Comando()
        {
            TimeStamp = DateTime.Now;
        }
    }
}