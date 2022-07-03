using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ToDo.WEB.Controllers
{
    public class BaseController : Controller
    {
        public int? GetCurrentUserID()
        {
            var userId = HttpContext?.User?.Claims?.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;

            if (string.IsNullOrWhiteSpace(userId))
                return null;

            int.TryParse(userId, out int id);
            return id;
        }
    }
}
