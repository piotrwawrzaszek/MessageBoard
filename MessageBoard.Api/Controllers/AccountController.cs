using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Infrastructure.Services;
using MessageBoard.Infrastructure.Commands;
using MessageBoard.Infrastructure.Commands.Users;
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

        [HttpPut("password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}