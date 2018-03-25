using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageBoard.Infrastructure.Commands;
using MessageBoard.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Infrastructure.Commands.Posts;

namespace MessageBoard.Api.Controllers
{
    public class PostsController : ApiControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(ICommandDispatcher commandDispatcher,
            IPostService postService) : base(commandDispatcher)
        {
            _postService = postService;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.BrowseAsync();
            return Json(posts);
        }

        //[Authorize]
        [HttpGet("{postId}")]
        public async Task<IActionResult> Get(Guid postId)
        {
            var post = await _postService.GetAsync(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Json(post);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPost command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}