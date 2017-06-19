using System.Threading.Tasks;
using MessageBoard.Core.Domain;
using MessageBoard.Infrastructure.Commands;
using MessageBoard.Infrastructure.Commands.Posts;
using MessageBoard.Infrastructure.Services;

namespace MessageBoard.Infrastructure.Handlers.Posts
{
    public class AddPostHandler : ICommandHandler<AddPost>
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly ICategoryProvider _categoryProvider;

        public AddPostHandler(IPostService postService, IUserService userService,
            ICategoryProvider categoryProvider)
        {
            _postService = postService;
            _userService = userService;
            _categoryProvider = categoryProvider;
        }
        public async Task HandleAsync(AddPost command)
        {
            var user = await _userService.GetAsync(command.Email);
            //var group = await _groupService.GetAsync(command.GroupId);
            var categoryDetails = await _categoryProvider.GetAsync(command.CategoryType, command.CategoryName);
            var category = Category.Create(command.CategoryType, categoryDetails.Name, categoryDetails.Description);
            //await _postService.AddAsync(Guid.NewGuid(), group, user, command.Content, category);
        }
    }
}

