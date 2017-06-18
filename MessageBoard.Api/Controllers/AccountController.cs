using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessengerBoard.Infrastructure.Services;
using MessengerBoard.Infrastructure.Commands;
using MessengerBoard.Infrastructure.Commands.Users;
using Microsoft.AspNetCore.Authorization;

namespace MessageBoard.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(ICommandDispatcher commandDispatcher, IJwtHandler handler) 
            : base(commandDispatcher)
        {
            _jwtHandler = handler;
        }

        [HttpGet("token")]
        public IActionResult Get()
        {
            var token =_jwtHandler.CreateToken("user1@email.com", "user");
            return Json(token);
        }

        [HttpGet("auth")]
        [Authorize(Policy = "admin")]
        public IActionResult GetAuth()
        {
            return Content("Auth");
        }

        [HttpPut("password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}