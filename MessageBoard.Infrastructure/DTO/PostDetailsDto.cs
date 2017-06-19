using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Infrastructure.DTO
{
    public class PostDetailsDto : PostDto
    {
        public IEnumerable<UserDto> UpvotingUsers { get; set; }
        public IEnumerable<UserDto> DownvotingUsers { get; set; }
        public IEnumerable<PostDetailsDto> PostChildren { get; set; }
    }
}
