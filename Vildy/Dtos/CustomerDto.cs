using System;
using System.ComponentModel.DataAnnotations;
using Vildy.Models;

namespace Vildy.Dtos
{
	public class CustomerDto
	{


		public int ID { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Display(Name = "Date of Birth")]
		public DateTime? BirthDay { get; set; }

		public bool IsSubscribedToNewsLetter { get; set; }

		[Display(Name = "Membership Type")]
		public byte MemberShipTypeID { get; set; }

		public MembershipTypeDto MembershipType { get; set; }
	}
}