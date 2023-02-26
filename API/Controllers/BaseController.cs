using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected string GetCurrentUserId()
        {
            return User.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
}