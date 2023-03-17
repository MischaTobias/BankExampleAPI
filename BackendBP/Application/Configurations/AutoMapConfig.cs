using AutoMapper;
using Domain.Models;

namespace Application.Configurations;

public class AutoMapConfig : Profile
{
	public AutoMapConfig()
	{
        CreateMap<ClientDTO, Client>().ReverseMap()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember, destMember) => srcMember != null));
        CreateMap<ClientDTO, Person>().ReverseMap();
    }
}
