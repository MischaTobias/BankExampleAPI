using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Models;

namespace Application.Features.Clients.Commands.UpdateClient;

public record UpdateClientCommand(ClientDTO Client) : IRequest<Response<ClientDTO>> { }

public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Response<ClientDTO>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    public UpdateClientHandler(IClientRepository clientRepository, IPersonRepository personRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<Response<ClientDTO>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await new UpdateClientValidator().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var Errors = new List<string>(validationResult.Errors.Select(error => error.ErrorMessage));
            return new Response<ClientDTO> { Errors = Errors };
        }

        Client client = await _clientRepository.GetByIdAsync(request.Client.ClientId);
        if (client == null)
        {
            return new Response<ClientDTO> { Errors = new List<string> { "No existe el cliente con el id proporcionado" } };
        }

        return new Response<ClientDTO> { Success = true };
    }
}
