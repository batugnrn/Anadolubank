using Bank.Application.Abstractions;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Application.ViewModels.Customers;
using Bank.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
       
        //private readonly ICustomerService _customerService;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        public CustomersController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
          //  _customerService = customerService;
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        //[HttpGet]
        //public IActionResult GetCustomers()
        //{
        //    var customer = _customerService.GetCustomers();
        //    return Ok(customer);
        //}
        //[HttpGet]
        //public async Task Get()  
        //{
        //    await _customerWriteRepository.AddRangeAsync(new()
        //    {
        //        new() {Adress = "kkkkkkk", Birthday="11.11.1986", Email="afse@fd.gr", Gender="male",
        //        Name= "kkkk",  Surname= "surname6", PhoneNumber=05555555555, Tcno=11111111111, Password="123aa"},
        //    });
        //    var count = await _customerWriteRepository.SaveAsync();
        //}
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
            await _customerWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Surname = model.Surname,
                Gender = model.Gender,
                Email = model.Email,
                Birthday = model.Birthday,
                Adress  = model.Adress,
                PhoneNumber = model.Phone,
                Tcno = model.Tcno,
                Password = model.Password,

            });
            await _customerWriteRepository.SaveAsync();
            return Ok();
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
