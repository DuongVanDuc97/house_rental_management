using System.Text.Json;
using HR.API.Reponses;
using HR.BAL.Exceptions;

namespace HR.API.Middlewares;

public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;
	private readonly IWebHostEnvironment _env;

	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment env)
	{
		_next = next;
		_logger = logger;
		_env = env;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleException(context, ex);
		}
	}

	private Task HandleException(HttpContext context, Exception ex)
	{
		_logger.LogError(ex.Message);

		var code = StatusCodes.Status500InternalServerError;
		var errors = new List<string> { ex.Message };

		code = ex switch
		{
			NotFoundException => StatusCodes.Status404NotFound,
			BadRequestException => StatusCodes.Status400BadRequest,
			_ => code
		};
		
		var result = JsonSerializer.Serialize(ApiResult<string>.Failure(errors));
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = code;

		return context.Response.WriteAsync(result);
	}
}