using Application.Interfaces.Repositories;
using AutoMapper;

namespace Application.Features.Clients.Queries.GetClients;

public class GetClientsQuery : IRequest<Response<IEnumerable<ClientDTO>>> { }

public class GetClientsHandler : IRequestHandler<GetClientsQuery, Response<IEnumerable<ClientDTO>>>
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public GetClientsHandler(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<ClientDTO>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return new Response<IEnumerable<ClientDTO>>() { 
            Success = true,
            Result = _mapper.Map<IEnumerable<ClientDTO>>(await _clientRepository.GetAllAsync()) 
        };
    }
}
