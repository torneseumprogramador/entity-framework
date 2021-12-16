using System;
using MediatR;

namespace Entity.Shared.Mensagens
{
    public class Command : IRequest<bool>
    {
         public DateTime TimeStamp { get; set;}

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}