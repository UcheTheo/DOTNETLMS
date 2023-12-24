using System;
using LMS_DATA_SERVICE.IRepository;

namespace LMS_DATA_SERVICE.IConfiguration;

public interface ILMSUnitOfWork
{
	IUsersRepository Users { get; }

	Task SaveToDbAsync();
}
