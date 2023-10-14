using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using MusicAPI.HELPRES.Attrubutes;
using MusicAPI.HELPRES.Helper;

namespace MusicAPI.HELPRES.Middleware;

public class ConditionalMiddleware
{
	private readonly RequestDelegate _next;

	public ConditionalMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		var endpoint = context.GetEndpoint();

		if (endpoint != null)
		{
			var actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

			var useTokenAttribute = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(UseTokenMiddlewareAttribute), false);

			if (useTokenAttribute.Length > 0)
			{
				if (context.Request.Headers.TryGetValue("token", out var tokenHeader))
				{
					try
					{
						var userId = JwtTokenHelper.ValidateTokenAndGetUserId(tokenHeader);

						if (userId != -1)
						{
							context.Items["UserId"] = userId;
						}
						else
						{
							context.Response.StatusCode = StatusCodes.Status401Unauthorized;
							return;
						}
					}
					catch (Exception ex)
					{
						context.Response.StatusCode = StatusCodes.Status401Unauthorized;
						return;
					}
				}
				else
				{
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;
					return;
				}

				await _next(context);
				return;
			}
		}

		await _next(context);
	}
}