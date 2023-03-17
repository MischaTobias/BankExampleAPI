using Application.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Implements.Generic;

public class GenericRepository<TDomain, TPersistence> : IGenericRepository<TDomain> where TDomain : class where TPersistence : class
{
    protected readonly DevsuContext _dbContext;
    protected readonly IMapper _mapper;
    public GenericRepository(DevsuContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async ValueTask<TDomain> CreateAsync(TDomain model)
    {
        TPersistence entity = _mapper.Map<TPersistence>(model);
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return model;
    }

    public async ValueTask<IEnumerable<TDomain>> GetAllAsync() => _mapper.Map<IEnumerable<TDomain>>(await _dbContext.Set<TPersistence>().ToListAsync());
    public async ValueTask<TDomain> GetByIdAsync(int Id) => _mapper.Map<TDomain>(await _dbContext.Set<TPersistence>().FindAsync(Id));

    public async ValueTask UpdateAsync(TDomain model)
    {
        TPersistence entity = _mapper.Map<TPersistence>(model);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DeleteAsync(TDomain model)
    {
        TPersistence entity = _mapper.Map<TPersistence>(model);
        _dbContext.Set<TPersistence>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}
