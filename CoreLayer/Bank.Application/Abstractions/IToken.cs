using Bank.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Abstractions
{
    public interface IToken
    {
        Token CreateToken(int minute);
    }
}
