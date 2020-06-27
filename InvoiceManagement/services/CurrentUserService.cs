using System.Security.Claims;
using Application.common;
using Microsoft.AspNetCore.Http;

namespace InvoiceManagement.services
{
    public class CurrentUserService : ICurrentUserService
    {
        //make ctor and get request
        public CurrentUserService(IHttpContextAccessor httpContextAccessor  )
        {
            this.UserId=httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            //meken current user name eka genalla denawa
        }
        public string UserId {get;}
    }
}