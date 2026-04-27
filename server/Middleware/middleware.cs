using System.IdentityModel.Tokens.Jwt;

namespace server.Middleware
{
    public class middleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<CustomMiddleware> _logger;

        public middleware(RequestDelegate next/* ILogger<CustomMiddleware> logger*/)
        {
            _next = next;
            // _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();

                // חילוץ המידע מהטוקן
                var userId = ExtractUserIdFromToken(token);

                if (!string.IsNullOrEmpty(userId))
                {
                    // הוספת ה-userId ל-HttpContext
                    context.Items["UserId"] = userId;
                }
            }

            await _next(context);
        }

        private string ExtractUserIdFromToken(string token)
        {
            // דוגמת פענוח טוקן (JWT)
            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId");
                return userIdClaim?.Value;
            }

            return null;
        }
    }
}
