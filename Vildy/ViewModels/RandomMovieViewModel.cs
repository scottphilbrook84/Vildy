using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vildy.Models;

namespace Vildy.ViewModels
{
	public class RandomMovieViewModel
	{
		public Movie Movie { get; set; }
		public IList<Customer> Customers { get; set; }
	}
}