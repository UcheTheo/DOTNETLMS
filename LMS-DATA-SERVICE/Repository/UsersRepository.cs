using LMS_DATA_SERVICE.Data;
using LMS_DATA_SERVICE.IRepository;
using LMS_ENTITIES.DbSet;
using Microsoft.Extensions.Logging;

namespace LMS_DATA_SERVICE.Repository;

public class UsersRepository : GenericRepository<User>, IUsersRepository
{
	public UsersRepository(LMSDbContext context, ILogger logger) : base(context, logger)
	{
	}
}

