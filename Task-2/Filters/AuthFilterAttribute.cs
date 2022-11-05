using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Task_2.Data;

namespace Task_2.Filters;

public class AuthFilterAttribute : ActionFilterAttribute
{
    private readonly AppDbContext _context;

    public AuthFilterAttribute(AppDbContext context)
    {
        _context = context;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.ContainsKey("Token"))
        {
            context.Result = new UnauthorizedResult();

            return;
        }
      
        var token = context.HttpContext.Request.Headers["Token"];

        var user = _context.Users.ToList().FirstOrDefault(u => u.Token == token);

        if (user == null)
        {
            context.Result = new UnauthorizedResult();

            return;
        }

    }
}
