using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.QueryHandlers
{
    public class GetCustomerByIdQueryHandle : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        public GetCustomerByIdQueryHandle(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }
        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Customers customers = await _customerReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Customers = customers,
            };
            
        }
    }
}
