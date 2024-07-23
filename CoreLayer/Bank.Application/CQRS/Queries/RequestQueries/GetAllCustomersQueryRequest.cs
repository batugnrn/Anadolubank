using Bank.Application.CQRS.Queries.ResponseQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Queries.RequestQueries
{
    public class GetAllCustomersQueryRequest : IRequest<GetAllCustomersQueryResponse>
    {
        
    }
}
