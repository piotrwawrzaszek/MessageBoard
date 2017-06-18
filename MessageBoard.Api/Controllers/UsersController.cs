using System.Threading.Tasks;
using MessengerBoard.Infrastructure.Commands;
using MessengerBoard.Infrastructure.Commands.Users;
using Microsoft.AspNetCore.Mvc;
using MessengerBoard.Infrastructure.Services;

namespace MessageBoard.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, 
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new object());
        }
    }
}