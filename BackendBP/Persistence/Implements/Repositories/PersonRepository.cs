using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Implements.Repositories;

public class PersonRepository : GenericRepository<Domain.Models.Person, Person>, IPersonRepository
{ 
	public PersonRepository(DevsuContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{
	}

    public async ValueTask<Domain.Models.Person> GetByPersonIdentification(string identification)
    {
        return _mapper.Map<Domain.Models.Person>(await _dbContext.People
            .Where(c => c.Identification == identification)
            .FirstOrDefaultAsync());
    }
}
