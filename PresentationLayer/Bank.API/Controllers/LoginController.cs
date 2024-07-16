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
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomerReadRepository customerReadRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerReadRepository = customerReadRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(VmCreateAppUser user)
        {
            Customers custom;
            string id = "";
            custom = _customerReadRepository.GetWhere(x => x.Tcno.ToString() == user.Tcno).FirstOrDefault();
            id = custom.Id.ToString();


            AppUser userr = await _userManager.FindByIdAsync(id);
            if (userr == null)
            {
                throw new Exception("Kullanıcı yok");
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.CheckPasswordSignInAsync(userr, user.Password, false);
            if (result.Succeeded) {
                throw new Exception("Kullanıcı var");
            }
            return Ok();
        }
    }
}
