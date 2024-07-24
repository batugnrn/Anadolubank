using Bank.Application.Abstractions;
using Bank.Application.CQRS.Commands.RequestCommands;
using Bank.Application.CQRS.Commands.ResponseCommands;
using Bank.Application.CQRS.Queries.RequestQueries;
using Bank.Application.CQRS.Queries.ResponseQueries;
using Bank.Application.Repositories.CustomerRepository;
using Bank.Application.ViewModels.Customers;
using Bank.Domain.Entities;
using Bank.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }   
        
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromRoute]GetAllCustomersQueryRequest allCustomersQueryRequest)
        {
            GetAllCustomersQueryResponse response =  await _mediator.Send(allCustomersQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute]GetCustomerByIdQueryRequest getCustomerByIdQueryRequest)
        {
            GetCustomerByIdQueryResponse response = await _mediator.Send(getCustomerByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(PostCustomerCommandRequest postCustomerCommandRequest)
        {
            PostCustomerCommandResponse response = await _mediator.Send(postCustomerCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomer(PutCustomerCommandRequest putCustomerCommandRequest)
        {
            PutCustomerCommandResponse response = await _mediator.Send(putCustomerCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerCommandRequest deleteCustomerCommandRequest)
        {
            DeleteCustomerCommandResponse response = await _mediator.Send(deleteCustomerCommandRequest);
            return Ok(response);
        }
    }
}
