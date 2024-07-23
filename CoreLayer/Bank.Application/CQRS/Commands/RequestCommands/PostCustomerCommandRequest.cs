using Bank.Application.CQRS.Commands.ResponseCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Commands.RequestCommands
{
    public class PostCustomerCommandRequest : IRequest<PostCustomerCommandResponse>
    {
        public string Adress { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public long Phone { get; set; }
        public long Tcno { get; set; }
        public string Password { get; set; }
    }
}
