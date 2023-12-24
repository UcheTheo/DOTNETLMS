using LMS_DATA_SERVICE.IConfiguration;
using LMS_DATA_SERVICE.IRepository;
using LMS_DATA_SERVICE.Repository;
using Microsoft.Extensions.Logging;

namespace LMS_DATA_SERVICE.Data;

public class LMSUnitOfWork : ILMSUnitOfWork, IDisposable
{
	private readonly LMSDbContext _context;
	private readonly ILogger _logger;

	public IUsersRepository Users { get; private set; }

	public LMSUnitOfWork(LMSDbContext context, ILogger<LMSUnitOfWork> logger)
	{
		_context = context;
		_logger = logger;

		Users = new UsersRepository(context, _logger);
	}

	public async void Dispose()
	{
		await _context.DisposeAsync();
	}

	public async Task SaveToDbAsync()
	{
		await _context.SaveChangesAsync();
	}
}
