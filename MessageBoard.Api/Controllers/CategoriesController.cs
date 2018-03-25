using System;
using System.Threading.Tasks;
using MessageBoard.Infrastructure.Commands;
using MessageBoard.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MessageBoard.Api.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        private readonly ICategoryProvider _categoryProvider;

        public CategoriesController(ICommandDispatcher commandDispatcher,
            ICategoryProvider categoryProvider) : base(commandDispatcher)
        {
            _categoryProvider = categoryProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryProvider.BrowseAsync();
            return Json(categories);
        }

        [HttpGet("{type}/{name}")]
        public async Task<IActionResult> Get(string type, string name)
        {
            var category = await _categoryProvider.GetAsync(type, name);
            if (category == null)
            {
                return NotFound();
            }
            return Json(category);
        }
    }
}