using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Models;

namespace Application.Features.Clients.Commands.CreateClient;

public record CreateClientCommand(ClientDTO Client) : IRequest<Response<int>> { }

public class CreateClientHandler : IRequestHandler<CreateClientCommand, Response<int>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public CreateClientHandler(IClientRepository clientRepository, IPersonRepository personRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await new CreateClientValidator().ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var Errors = new List<string>(validationResult.Errors.Select(error => error.ErrorMessage));
            return new Response<int> { Errors = Errors };
        }

        Person person = await _personRepository.GetByPersonIdentification(request.Client.Identification);
        if(person == null)
        {
            var personEntity = _mapper.Map<Person>(request.Client);
            person = await _personRepository.CreateAsync(personEntity);
        }

        Client client = await _clientRepository.GetByPersonId(person.PersonId);
        if (client != null)
        {
            return new Response<int> { 
                Errors = new List<string> { 
                    $"Ya existe una cuenta con el identificador {request.Client.Identification}, el Id de cuenta es {client.ClientId}" 
                } 
            };
        }

        var clientEntity = _mapper.Map<Client>(request.Client);
        clientEntity.PersonId = person.PersonId;
        var newClient = await _clientRepository.CreateAsync(clientEntity);

        return new Response<int>() { Success = true, Result = newClient.ClientId };
    }
}
