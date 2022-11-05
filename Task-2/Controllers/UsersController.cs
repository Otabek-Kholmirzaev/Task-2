using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_2.Data;
using Task_2.Entities;
using Task_2.Filters;
using Task_2.Models;
using Task_2.Services;

namespace Task_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddUser(CreateUserModel createUserModel)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            Name = createUserModel.Name,
            Email = createUserModel.Email,
            Token = Guid.NewGuid().ToString(),
        };
       
        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    { 
        var users = _context.Users.ToList();

        return Ok(users);
    }

    
    [HttpGet("problem")]
    [TypeFilter(typeof(AuthFilterAttribute))]
    public IActionResult Problem(int n, int k)
    {
        if (n <= 0 || n > int.MaxValue || k < 0 || k > 9)
            return BadRequest();

        var ans = SolutionService.GetProblemAnswer(n, k);

        return Ok(ans);
    }


}
