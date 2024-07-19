using Bank.Application.Abstractions;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Application.ViewModels.Customers;
using Bank.Domain.Entities;
using Bank.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly RoleManager<AppRole> _roleManager;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        public CustomersController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, UserManager<AppUser> userManager)//, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
          //  _roleManager = roleManager;
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }   
        
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(_customerReadRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(string id)
        {
           Customers c = await _customerReadRepository.GetByIdAsync(id);
           return Ok(c);
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomer(VmCreateCustomer model)
        {
            Guid guid = Guid.NewGuid();
            var result = await _userManager.CreateAsync(new()
            {
                Id = guid.ToString(),
                Tcno = model.Tcno.ToString(),
                PhoneNumber = model.Phone.ToString(),
                Email = model.Email.ToString(),
                UserName = guid.ToString(),

            }, model.Password.ToString());


            if (result.Succeeded)
            {
                await _customerWriteRepository.AddAsync(new()
                {
                    Id = guid,
                    Name = model.Name,
                    Surname = model.Surname,
                    Gender = model.Gender,
                    Email = model.Email,
                    Birthday = model.Birthday,
                    Adress = model.Adress,
                    PhoneNumber = model.Phone,
                    Tcno = model.Tcno,
                    Password = model.Password,
                    Account = new()
                     {
                        Id = guid,
                        Balance = 0,
                     }

                });
                await _customerWriteRepository.SaveAsync();
                //AppUser appUser = await _userManager.FindByIdAsync(guid.ToString());
                //await _userManager.AddToRoleAsync(appUser,"Customer");


                return Ok();
            }
            else { return BadRequest(result); }

            
        }
        [HttpPut]
        public async Task<IActionResult> PutCustomer(VmCreateCustomer model, string id)
        {
            Customers c = await _customerReadRepository.GetByIdAsync(id);
            c.Name = model.Name;
            c.Surname = model.Surname;
            c.Gender = model.Gender;
            c.Email = model.Email;
            c.Birthday = model.Birthday;
            c.Adress = model.Adress;
            c.PhoneNumber = model.Phone;
            c.Tcno = model.Tcno;
            c.Password = model.Password;
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _customerWriteRepository.RemoveAsync(id);
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
