using Application.Contracts.SecurityApp;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Security.TokenAccess
{
    public class GetUserSession : IGetUserSession
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public GetUserSession(IHttpContextAccessor contextAccessor) { 
                _contextAccessor = contextAccessor;
        }
        string IGetUserSession.GetUserId()
        {
            try
            {
                string? userId = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(a => a.Type.Equals(ClaimTypes.Sid))?.Value;
                return userId;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
