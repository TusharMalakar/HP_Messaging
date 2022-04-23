using System.Linq;
using HP_Messaging.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using HP_Messaging.Entities;

namespace HP_Messaging.Security
{
    public class CustomRouteAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomRouteAuthorizeAttribute() : base(typeof(RouteRequirementFilter))
        {
            Arguments = System.Array.Empty<object>();
        }
    }

    public class RouteRequirementFilter : IAuthorizationFilter
    {
        private readonly ClaimsPrincipal _principal;
        private readonly AppSettings _appSettings;
        private readonly ChatContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public RouteRequirementFilter(IPrincipal principal, IOptions<AppSettings> appSettings, IHttpContextAccessor contextAccessor, ChatContext dbContext)
        {
            _principal = principal as ClaimsPrincipal;
            _contextAccessor = contextAccessor;
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //AllowAnonymous Check
            var allowAnonymous = context?.ActionDescriptor.EndpointMetadata.OfType<Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute>().Any() ?? false;
            if (allowAnonymous) { return; }

            //Authentication check
            //if (!_contextAccessor.HttpContext.Request.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    context.Result = new ForbidResult();
            //}

            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new ForbidResult();
            }
            var authHeader = context.HttpContext.Request.Headers["Authorization"][0];
            if (authHeader.StartsWith("Bearer "))
            {
                var authToken = authHeader.Substring("Bearer ".Length);
                if (authToken == null)
                {
                    context.Result = new ForbidResult();
                }
                var email = HashHelper.DecryptHash(authToken);
                if (email == null)
                {
                    context.Result = new ForbidResult();
                }
                var user = _dbContext.Users.FirstOrDefault(user => user.Email == email);
                if (user==null)
                {
                    context.Result = new ForbidResult();
                }
                _dbContext.profile = user;
            }
          }


        //public class NoReadOnlyAccess : TypeFilterAttribute
        //{
        //    public NoReadOnlyAccess() : base(typeof(ReadOnlyRequirementFilter))
        //    {
        //        Arguments = System.Array.Empty<object>();
        //    }
        //}

    }
}