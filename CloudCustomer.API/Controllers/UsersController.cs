using CloudCustomer.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloudCustomer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpGet(Name ="GetUsers")]

        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersService.GetUsers();
            if (users.Any())
            {
                return Ok(users);

            }
            return NotFound();
        }

    }
}
