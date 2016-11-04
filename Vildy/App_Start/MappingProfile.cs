using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Vildy.Dtos;
using Vildy.Models;

namespace Vildy.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			//Domain to Dto
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<Movie, MovieDto>();
			Mapper.CreateMap<MembershipType, MembershipTypeDto>();

			//Dto To Domain 
			Mapper.CreateMap<CustomerDto, Customer>()
				  .ForMember(c => c.ID, opt => opt.Ignore());

			Mapper.CreateMap<MovieDto, Movie>()
				  .ForMember(c => c.Id, opt => opt.Ignore());

			Mapper.CreateMap<MembershipTypeDto, MembershipType>()
				  .ForMember(c => c.Id, opt => opt.Ignore());

		}

	}
}