using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vildy.Dtos;
using Vildy.Models;

namespace Vildy.Controllers.API
{
    public class CustomersController : ApiController
    {

		private ApplicationDbContext _context; 
 
		public CustomersController()
		{
			_context = new ApplicationDbContext();

		}

		//GET api/customers 
		public IEnumerable<CustomerDto> GetCustomers()
		{

			return _context.Customers
						   .Include(c => c.MembershipType)
						   .ToList()
						   .Select(Mapper.Map<Customer, CustomerDto>);
		}

		//GET api/customers/1
		public CustomerDto GetCustomer(int customerID)
		{
			var customer = _context.Customers.SingleOrDefault(x => x.ID == customerID);

			if (customer == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			return Mapper.Map<Customer, CustomerDto>(customer); 
		}

		//POST api/customers
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{

			if (!ModelState.IsValid)
				return BadRequest();

			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();

			customerDto.ID = customer.ID;

			return Created(new Uri(Request.RequestUri + "/" + customer.ID), customerDto);
		}

		//PUT api/customers/1
		[HttpPut]
		public void UpdateCustomer(int customerID, CustomerDto customerDto)
		{

			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var customerInDB = _context.Customers.SingleOrDefault(x => x.ID == customerID);

			if (customerInDB == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			Mapper.Map(customerDto, customerInDB);

			_context.SaveChanges();
		}

		//DELETE api/customers/1
		[HttpDelete]
		public IHttpActionResult DeleteCustomer(int id)
		{
			var customerInDB = _context.Customers.SingleOrDefault(x => x.ID == id);

			if (customerInDB == null)
				return NotFound();

			_context.Customers.Remove(customerInDB);

			_context.SaveChanges();

			return Ok();

		}
    }
}
