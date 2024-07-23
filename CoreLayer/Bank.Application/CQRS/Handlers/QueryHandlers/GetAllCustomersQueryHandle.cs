using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.DTOs;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.QueryHandlers
{
    public class GetAllCustomersQueryHandle : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersQueryResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        public GetAllCustomersQueryHandle(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }
        public async Task<GetAllCustomersQueryResponse> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            List<Customers> customersList = await _customerReadRepository.GetAll().ToListAsync();
            List<CustomerDTOs> responseList = customersList.Select(item => new CustomerDTOs
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
                Gender = item.Gender,
                Tcno = item.Tcno,
                Birthday = item.Birthday,
                CreatedDate = item.CreatedDate,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
                Adress = item.Adress,
                Password = item.Password,
                Account = item.Account
            }).ToList();

            return new GetAllCustomersQueryResponse
            {
                Customers = responseList
            };
   
        }
    }
}
