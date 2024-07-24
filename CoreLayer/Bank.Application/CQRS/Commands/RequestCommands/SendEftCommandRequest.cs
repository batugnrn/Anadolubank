using Bank.Application.CQRS.Commands.ResponseCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Commands.RequestCommands
{
    public class SendEftCommandRequest : IRequest<SendEftCommandResponse>
    {
        public int receiverAccountNumber { get; set; }
        public int senderAccountNumber { get; set; }
        public float amount { get; set; }
        public string? message { get; set; }
    }
}
