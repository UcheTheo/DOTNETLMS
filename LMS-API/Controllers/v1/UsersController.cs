using AutoMapper;
using Azure.Core;
using FluentValidation.Results;
using LMS_DATA_SERVICE.IConfiguration;
using LMS_ENTITIES.DbSet;
using LMS_ENTITIES.DTOs.Generic;
using LMS_ENTITIES.DTOs.Incoming.User;
using LMS_ENTITIES.DTOs.Outgoing.User;
using LMS_ENTITIES.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers.v1;

public class UsersController : BaseController
{
	private readonly ILogger<UsersController> _logger;
	public UsersController(
		ILMSUnitOfWork lmsUnitOfWork,
		IMapper mapper,
		ILogger<UsersController> logger) : base(lmsUnitOfWork, mapper)
	{
		_logger = logger;
	}

	public async Task<IActionResult> GetUsers()
	{
		var users = await _lmsUnitOfWork.Users.All();

		var result = new PagedResult<User>()
		{
			Content = users.ToList(),
			ResultCount = users.Count()
		};
		return Ok(result);
	}

	[HttpPost]
	public async Task<IActionResult> AddUser(CreateUserDto user)
	{
		// Validate the request using FluentValidation
		var validator = new UserValidator();
		ValidationResult validationResult = validator.Validate(user);

		if (!validationResult.IsValid)
		{
			// Handle validation errors, for example, return BadRequest
			return BadRequest(validationResult.Errors);
		}

		var result = new Result<CreateUserDto>();

		try
		{
			var _mappedUser = _mapper.Map<User>(user);

			await _lmsUnitOfWork.Users.Add(_mappedUser);
			await _lmsUnitOfWork.SaveToDbAsync();

			//_context.Users.Add(_user);
			//_context.SaveChanges();

			result.Content = user;
			result.IsSuccess = true;

			return CreatedAtRoute("GetUser", new { id = _mappedUser.Id }, result); // return 201

		}
		catch (Exception ex)
		{
			_logger.LogError(
			"Request failure {@RequestName}, {@Error}, {@DateTimeUtc}",
			typeof(CreateUserDto).Name,
			ex.Message,
			DateTime.UtcNow);
		}
		return BadRequest(result);
	}

	[HttpGet]
	[Route("GetUser", Name ="GetUser")]
	public async Task<IActionResult> GetUser(Guid id)
	{
		var userRepository = _lmsUnitOfWork.Users;
		userRepository.Include(u => u.Avatar);

		var user = await userRepository.GetById(id);

		//var user = await _lmsUnitOfWork.Users.Include(u => u.Avatar)
		//	.GetById(id);

		var result = new Result<GetUserDto>();
		if (user != null)
		{
			var mappedProfile = _mapper.Map<GetUserDto>(user);

			result.Content = mappedProfile;
			result.IsSuccess = true;

			return Ok(result);
		}

		_logger.LogError(
			"Request failure {@RequestName}, {@Error}, {@DateTimeUtc}",
			typeof(GetUserDto).Name,
			result.Error,
			DateTime.UtcNow);

		return BadRequest(result);
	}
}
