using Application.Interfaces.Generic;
using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IClientRepository : IGenericRepository<Client>
{
    ValueTask<Client> GetByPersonId(int personId);
    ValueTask<IEnumerable<Client>> GetClientsWithPersonInfo();
    ValueTask<Client> GetClientWithPersonInfoById(int clientId);
}
