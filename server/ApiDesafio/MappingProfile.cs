using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace ApiDesafio;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Company, CompanyDto>()
			.ForMember(c => c.FullAddress,
			opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

		CreateMap<Employee, EmployeeDto>();
		CreateMap<Titulo, TituloDto>();
		CreateMap<Titulo, TituloResponseDto>()
			.ReverseMap();
		CreateMap<Titulo, TituloResumoDto>();
		CreateMap<Parcela, ParcelaDtoResponse>();

        CreateMap<CompanyForCreationDto, Company>();
        
        CreateMap<TituloForCreateionDto,Titulo > ()
	        .ReverseMap();
        
        CreateMap<ParcelaForCreateionDto,Parcela > ()
	        .ReverseMap();

  
        CreateMap<EmployeeForCreationDto, Employee>();

        CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        CreateMap<CompanyForUpdateDto, Company>();

        CreateMap<UserForRegistrationDto, User>();
        
        
    }
}
