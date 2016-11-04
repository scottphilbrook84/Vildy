using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vildy.Dtos
{
	public class MovieDto
	{

		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Movie genre type")]
		public byte MovieGenreTypeID { get; set; }

		[Required]
		[Display(Name = "Release date")]
		public DateTime ReleaseDate { get; set; }

		[Required]
		[Range(1, 20)]
		[Display(Name = "Number in Stock")]
		public int InStock { get; set; }

		[Required]
		[Display(Name = "Date added")]
		public DateTime DateAdded { get; set; }

	}
}