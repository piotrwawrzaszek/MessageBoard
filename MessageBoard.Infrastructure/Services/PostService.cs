using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MessageBoard.Core.Domain;
using MessageBoard.Core.Repositories;
using MessageBoard.Infrastructure.DTO;

namespace MessageBoard.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryProvider _categoryProvider;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper,
            ICategoryProvider categoryProvider)
        {
            _postRepository = postRepository;
            _categoryProvider = categoryProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> BrowseAsync()
        {
            var posts = await _postRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDetailsDto> GetAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            return _mapper.Map<Post, PostDetailsDto>(post);
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);
            await _postRepository.DeleteAsync(post);
        }

        public async Task AddAsync(Guid id, Group group, User author, string content, Category category)
        {
            var post = await _postRepository.GetAsync(id);
            if (post != null)
            {
                throw new Exception($"Post with id: '{id}' already exist.");
            }
            post = new Post(id, group, author, content, category);
            await _postRepository.AddAsync(post);
        }
        
        public async Task SetCategory(Guid postId, string type, string name)
        {
            var post = await _postRepository.GetAsync(postId);
            if (post == null)
            {
                throw new Exception($"Post with id: '{postId}' was not found.");
            }
            var categoryDetails = await _categoryProvider.GetAsync(type, name);
            var category = Category.Create(type, categoryDetails.Name, categoryDetails.Description);
            post.SetCategory(category);
        }
    }
}
