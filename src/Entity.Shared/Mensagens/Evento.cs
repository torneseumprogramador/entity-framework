using System;

namespace Entity.Shared.Mensagens
{
    public abstract class Evento : INotificacao
    {
        public DateTime TimeStamp { get; set;}
        public Evento()
        {
            TimeStamp = DateTime.Now;
        }
    }
}