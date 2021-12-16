using System;
using MediatR;

namespace Entity.Shared.Mensagens
{
    public class Event : INotification
    {
        public DateTime TimeStamp { get; set;}
        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}