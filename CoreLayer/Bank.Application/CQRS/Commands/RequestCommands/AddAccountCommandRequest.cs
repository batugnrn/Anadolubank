using Bank.Application.CQRS.Commands.ResponseCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Commands.RequestCommands
{
    public class AddAccountCommandRequest : IRequest<AddAccountCommandResponse>
    {
        public string Id { get; set; }
    }
}
