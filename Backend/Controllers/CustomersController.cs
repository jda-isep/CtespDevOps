using System;
using System.Collections.Generic;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private List<Customers> Customers = new List<Customers>();


        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
            LoadData();

        }

        private void LoadData()
        {
            Customers.Add(new Customers { Id = 1, Name = "Isaac Garrison", RegisterDate = Convert.ToDateTime("01-12-2019"), Status = true });
            Customers.Add(new Customers { Id = 2, Name = "Elisabeth Mcgrath", RegisterDate = Convert.ToDateTime("05-20-2020"), Status = true });
            Customers.Add(new Customers { Id = 3, Name = "Ariana Hughes", RegisterDate = Convert.ToDateTime("01-12-2019"), Status = true });
        }

        [HttpGet]
        public IEnumerable<Customers> Get()
        {

            return Customers;
        }
    }
}
