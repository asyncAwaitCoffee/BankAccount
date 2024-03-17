using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebBank2App.Filters
{
	public class UserIdAttribute : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			_ = int.TryParse(context.HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value, out int userId);
			context.ActionArguments["userId"] = userId;
			await next();
		}
	}
}
