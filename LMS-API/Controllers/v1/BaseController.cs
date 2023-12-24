using Asp.Versioning;
using AutoMapper;
using LMS_DATA_SERVICE.IConfiguration;
using LMS_ENTITIES.DTOs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace LMS_API.Controllers.v1;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
	protected ILMSUnitOfWork _lmsUnitOfWork;
	protected readonly IMapper _mapper;

	public BaseController(ILMSUnitOfWork lmsUnitOfWork, IMapper mapper)
	{
		_lmsUnitOfWork = lmsUnitOfWork;
		_mapper = mapper;
	}

	internal Error PopulateError(int code, string message, string type)
	{
		return new Error()
		{
			Code = code,
			Message = message,
			Type = type
		};
	}


}
