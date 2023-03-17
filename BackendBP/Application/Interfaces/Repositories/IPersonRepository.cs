using Application.Interfaces.Generic;
using Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IPersonRepository : IGenericRepository<Person>
{
    ValueTask<Person> GetByPersonIdentification(string identification);
}
