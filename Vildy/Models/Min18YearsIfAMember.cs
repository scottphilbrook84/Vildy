using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vildy.Models
{
	public class Min18YearsIfAMember : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;
			if (customer.MemberShipTypeID == 0 || customer.MemberShipTypeID == 1)
				return ValidationResult.Success;

			if (customer.BirthDay == null)
				return new ValidationResult("Birthdate is required");

			var age = DateTime.Today.Year - customer.BirthDay.Value.Year;

			return (age >= 18)
					? ValidationResult.Success
					: new ValidationResult("Customer should be at least 18!");
		}
	}
}