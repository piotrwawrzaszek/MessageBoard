﻿using System.Threading.Tasks;

namespace MessageBoard.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
