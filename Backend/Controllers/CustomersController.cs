using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly List<Customers> Customers = new List<Customers>();


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

        [HttpGet("{id}")]
        public ActionResult<Customers> Get(int id)
        {
            var customer = Customers.FirstOrDefault((p) => p.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            try
            {
                customer.Status = true;
                customer.RegisterDate = DateTime.UtcNow;
                Customers.Add(customer);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok(customer);

        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Customers customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            Customers todoCustomer = Customers.FirstOrDefault(x=> x.Id == id);

            if (todoCustomer == null)
            {
                return NotFound();
            }

            todoCustomer.Name = customer.Name;
            todoCustomer.Status = customer.Status;

            return Ok(todoCustomer);
        }

    }
}
