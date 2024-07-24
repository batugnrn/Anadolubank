using Bank.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Commands.ResponseCommands
{
    public class LoginCommandResponse
    {
        public Token Token { get; set; }
    }
}
