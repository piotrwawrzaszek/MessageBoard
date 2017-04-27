using System;
using System.Collections.Generic;
using System.Text;

namespace MessageBoard.Core.Domain
{
    public class FriendList
    {
        public Guid Id { get; protected set; }
        public IEnumerable<User> Friends { get; protected set; }

        public FriendList(int dummy)
        {
            Id = Guid.NewGuid();
        }

        protected FriendList()
        {
        }

    }
}
