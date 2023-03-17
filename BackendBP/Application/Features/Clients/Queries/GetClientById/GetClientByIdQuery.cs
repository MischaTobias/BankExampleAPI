using Application.Features.Clients.Commands.CreateClient;
using Application.Interfaces.Repositories;
using AutoMapper;

namespace Application.Features.Clients.Queries.GetClientById;

public record GetClientByIdQuery(int id) : IRequest<Response<ClientDTO>> { }

public class GetClientByIdValidator : AbstractValidator<GetClientByIdQuery>
{
    public GetClientByIdValidator()
    {
        RuleFor(q => q.id)
            .NotNull()
            .GreaterThanOrEqualTo(1);
    }
}

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Response<ClientDTO>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public GetClientByIdHandler(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<Response<ClientDTO>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await new GetClientByIdValidator().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var Errors = new List<string>(validationResult.Errors.Select(error => error.ErrorMessage));
            return new Response<ClientDTO> { Errors = Errors };
        }

        var clientModel = await _clientRepository.GetClientWithPersonInfoById(request.id);
        var client = _mapper.Map<ClientDTO>(clientModel.Person);
        client.ClientId = clientModel.ClientId;
        //client.Password = clientModel.Password;

        return new Response<ClientDTO> { Success = true, Result = client };
    }
}
