using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vildy.Models;
using Vildy.ViewModels;

namespace Vildy.Controllers
{
    public class CustomersController : Controller
    {
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		//
        // GET: /Customers/
        public ActionResult Index()
        {
			return View();
        }

		public ActionResult New()
		{
			var membershipTypes = _context.MembershipTypes.ToList();
			var newCustomerViewModel = new CustomerFormViewModel();
			newCustomerViewModel.MembershipTypes = membershipTypes;
			newCustomerViewModel.Customer = new Customer();
			
			return View("CustomerForm", newCustomerViewModel);
		}


		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
			if (customer == null)
				HttpNotFound();

			var viewModel = new CustomerFormViewModel()
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new CustomerFormViewModel
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()	
				};

				return View("CustomerForm", viewModel);			
			}
			
			if (customer.ID == 0) 
				_context.Customers.Add(customer);
			else
			{
				var customerInDB = _context.Customers.Single(c => c.ID == customer.ID);
				customerInDB.Name = customer.Name;
				customerInDB.BirthDay = customer.BirthDay;
				customerInDB.MemberShipTypeID = customer.MemberShipTypeID;
				customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Customers");
		}

		public ActionResult Details(int id)
		{
			var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

	}
}