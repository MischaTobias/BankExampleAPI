using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Implements.Repositories;

public class ClientRepository : GenericRepository<Domain.Models.Client, Client>, IClientRepository
{ 
	public ClientRepository(DevsuContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{
	}

    public async ValueTask<Domain.Models.Client> GetByPersonId(int personId)
    {
        return _mapper.Map<Domain.Models.Client>(await _dbContext.Clients
            .Where(c => c.PersonId == personId)
            .FirstOrDefaultAsync());
    }

    public async ValueTask<IEnumerable<Domain.Models.Client>> GetClientsWithPersonInfo()
    {
        return _mapper.Map<IEnumerable<Domain.Models.Client>>(await _dbContext.Clients
            .Include(c => c.Person)
            .ToListAsync());
    }

    public async ValueTask<Domain.Models.Client> GetClientWithPersonInfoById(int clientId)
    {
        var clientEntity = await _dbContext.Clients.Include(c => c.Person)
            .Where(c => c.ClientId == clientId)
            .FirstOrDefaultAsync();

        var client = _mapper.Map<Domain.Models.Client>(clientEntity);
        client.Person = _mapper.Map<Domain.Models.Person>(clientEntity.Person);

        return client;
    }
}
