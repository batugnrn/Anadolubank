using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Domain.Entities;
using Bank.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Handlers.CommandHandlers
{
    public class PostCustomerCommandHandle : IRequestHandler<PostCustomerCommandRequest, PostCustomerCommandResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly UserManager<AppUser> _userManager;
        public PostCustomerCommandHandle(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, UserManager<AppUser> userManager)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _userManager = userManager;
        }
        public async Task<PostCustomerCommandResponse> Handle(PostCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Customers> customer1 = _customerReadRepository.GetWhere(x => x.Tcno == request.Tcno);
            if (customer1.Any()) throw new Exception("Bu Tcno'ya ait kullanıcı zaten var!..");

            IQueryable<Customers> customer2 = _customerReadRepository.GetWhere(x => x.PhoneNumber == request.Phone);
            if (customer2.Any()) throw new Exception("Bu Numaraya ait kullanıcı zaten var!..");

            IQueryable<Customers> customer3 = _customerReadRepository.GetWhere(x => x.Email == request.Email);
            if (customer3.Any()) throw new Exception("Bu Maile ait kullanıcı zaten var!..");

            Guid guid = Guid.NewGuid();
            var result = await _userManager.CreateAsync(new()
            {
                Id = guid.ToString(),
                Tcno = request.Tcno.ToString(),
                PhoneNumber = request.Phone.ToString(),
                Email = request.Email.ToString(),
                UserName = guid.ToString(),
            }, request.Password.ToString());

            if (result.Succeeded)
            {
                await _customerWriteRepository.AddAsync(new()
                {
                    Id = guid,
                    Name = request.Name,
                    Surname = request.Surname,
                    Gender = request.Gender,
                    Email = request.Email,
                    Birthday = request.Birthday,
                    Adress = request.Adress,
                    PhoneNumber = request.Phone,
                    Tcno = request.Tcno,
                    Password = request.Password,
                    Account = new()
                    {
                        Id = guid,
                        Balance = 0,
                    }
                });
                await _customerWriteRepository.SaveAsync();
                return new();
            }
            else 
            { 
                throw new Exception("BadRequest"); 
            }
        }
    }
}
