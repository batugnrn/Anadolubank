using Bank.Application.Abstractions;
using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.DTOs;
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
    public class LoginCommandHandle : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private ICustomerReadRepository _customerReadRepository;
        private readonly IToken _token;
        public LoginCommandHandle(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomerReadRepository customerReadRepository, IToken token)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerReadRepository = customerReadRepository;
            _token = token;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            Customers custom = _customerReadRepository.GetWhere(x => x.Tcno.ToString() == request.Tcno).FirstOrDefault();
            string id = custom.Id.ToString();


            AppUser userr = await _userManager.FindByIdAsync(id);
            if (userr == null)
            {
                throw new Exception("Kullanıcı yok");
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.CheckPasswordSignInAsync(userr, request.Password, false);
            if (result.Succeeded)
            {
                Token token = _token.CreateToken(5);
                token.Id = id;

                // throw new Exception("Kullanıcı başarılı giriş yaptı."); 
                return new LoginCommandResponse
                {
                    Token = token,
                };
            }
            else
            {
                throw new Exception("Başarısız Login!..");
            }
        }
    }
}
