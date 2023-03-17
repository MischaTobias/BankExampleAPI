using Application.Interfaces.Repositories;

namespace Persistence.Implements.Repositories;

public class AccountRepository : GenericRepository<Domain.Models.Account, Account>, IAccountRepository
{
	public AccountRepository(DevsuContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{
	}
}
