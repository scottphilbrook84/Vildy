using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vildy.Models;

namespace Vildy.ViewModels
{
	public class MovieFormViewModel
	{

		public MovieFormViewModel()
		{
			Id = 0;		
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			ReleaseDate = movie.ReleaseDate;
			DateAdded = movie.DateAdded;
			MovieGenreTypeID = movie.MovieGenreTypeID;
			InStock = movie.InStock;
			Name = movie.Name;
		}

		public IEnumerable<MovieGenreType> MovieGenreTypes{ get; set; }
		
		public int? Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public MovieGenreType MovieGenreType { get; set; }

		[Required]
		[Display(Name = "Movie genre type")]
		public byte? MovieGenreTypeID { get; set; }

		[Required]
		[Display(Name = "Release date")]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Range(1, 20)]
		[Display(Name = "Number in Stock")]
		public int? InStock { get; set; }

		[Required]
		[Display(Name = "Date added")]
		public DateTime? DateAdded { get; set; }

		public string Title {
			get
			{
				if (Id.HasValue)
					return "Edit Movie";


				return "New Movie";
			}
		}

	}
}