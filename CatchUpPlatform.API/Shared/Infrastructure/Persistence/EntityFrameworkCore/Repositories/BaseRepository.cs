using CatchUpPlatform.API.Shared.Domain.Repositories;
using DefaultNamespace.Repositories;

namespace CatchUpPlatform.API.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository where TEntity : class
{
    
}