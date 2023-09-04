using DashboardAPI.Dto;
using DashboardAPI.Helper;

namespace DashboardAPI
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;


        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var appkey = context.Request.Headers["appkey"].FirstOrDefault();
            var secretKey = context.Request.Headers["secretKey"].FirstOrDefault();
            if (
                !string.IsNullOrEmpty(appkey) && DBKeys.Appkey == appkey &&
                !string.IsNullOrEmpty(secretKey) && DBKeys.SecretKey == secretKey)
            {
                context.Items["User"] = new CustomPrincipal() { IsAuthenticated = true };
            }
            await _next(context);
        }
    }
}
