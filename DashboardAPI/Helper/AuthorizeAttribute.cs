using DashboardAPI.Dto;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DashboardAPI.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;
           
                // authorization
                var user = (CustomPrincipal)context.HttpContext.Items["User"];
                if (user == null || !user.IsAuthenticated)
                    context.Result = new JsonResult(new ResponseDto<string> { Code = HttpStatusCode.Unauthorized, IsSuccess = false, Message = "Unauthorized" });
            
        }
    }
}
