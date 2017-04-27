using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerBoard.Infrastructure.Commands.Users;
using MessengerBoard.Infrastructure.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessengerBoard.Infrastructure.Services;

namespace MessageBoard.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService; 

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);

        [HttpPost("")]
        public async Task Post([FromBody] CreateUser request)
            => await _userService.RegisterAsync(request.Email, request.Username, request.Password);
    }
}