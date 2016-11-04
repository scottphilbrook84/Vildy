using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vildy.ViewModels
{
	public class CustomerFormViewModel
	{

		public IEnumerable<Vildy.Models.MembershipType> MembershipTypes { get; set; }
		public Vildy.Models.Customer Customer { get; set; }

	}
}