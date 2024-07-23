using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.CommandHandlers
{
    public class PutCustomerCommandHandle : IRequestHandler<PutCustomerCommandRequest, PutCustomerCommandResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;

        public PutCustomerCommandHandle(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        public async Task<PutCustomerCommandResponse> Handle(PutCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            Customers c = await _customerReadRepository.GetByIdAsync(request.id);
            c.Name = request.Name;
            c.Surname = request.Surname;
            c.Gender = request.Gender;
            c.Email = request.Email;
            c.Birthday = request.Birthday;
            c.Adress = request.Adress;
            c.PhoneNumber = request.Phone;
            c.Tcno = request.Tcno;
            c.Password = request.Password;
            await _customerWriteRepository.SaveAsync();
            return new();
        }
    }
}
