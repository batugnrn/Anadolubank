using Bank.Application.Abstractions;
using Bank.Application.DTOs;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Application.ViewModels.Customers;
using Bank.Domain.Entities;
using Bank.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private ICustomerReadRepository _customerReadRepository;
        private readonly IToken _token;
        public LoginController(IToken token,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomerReadRepository customerReadRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerReadRepository = customerReadRepository;
            _token = token;
        }

        [HttpPost]
        public async Task<IActionResult> Login(VmCreateAppUser user)
        {
           
            Customers custom = _customerReadRepository.GetWhere(x => x.Tcno.ToString() == user.Tcno).FirstOrDefault();
            string id = custom.Id.ToString();


            AppUser userr = await _userManager.FindByIdAsync(id);
            if (userr == null)
            {
                throw new Exception("Kullanıcı yok");
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.CheckPasswordSignInAsync(userr, user.Password, false);
            if (result.Succeeded) {
               Token token = _token.CreateToken(5);
                token.Id = id;

                // throw new Exception("Kullanıcı başarılı giriş yaptı."); 
                return Ok(token);
            }
            return Ok();
        }
    }
}
