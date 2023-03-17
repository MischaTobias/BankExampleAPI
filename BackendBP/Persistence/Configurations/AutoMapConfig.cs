namespace Application.Configurations;

public class AutoMapConfig : Profile
{
	public AutoMapConfig()
	{
        CreateMap<Domain.Models.Client, Client>().ReverseMap();
        CreateMap<Domain.Models.Person, Person>().ReverseMap();
    }
}
