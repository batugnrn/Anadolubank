using Bank.Application.DTOs;
using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.CQRS.Queries.ResponseQueries
{
    public class GetAllCustomersQueryResponse 
    {
        public List<CustomerDTOs> Customers { get; set; }
    }
}
