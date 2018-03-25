using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MessageBoard.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            var tasks = new List<Task>();
            for (var i = 1; i <= 10; i++)
            {
                var user = $"user{i}";
                tasks.Add(_userService.RegisterAsync(Guid.NewGuid(), $"user{i}@email.com",
                    user, "secret", "user"));
                _logger.LogTrace($"Created a new user: '{user}'.");
            }
            for (var i = 1; i <= 3; i++)
            {
                var admin = $"admin{i}";
                tasks.Add(_userService.RegisterAsync(Guid.NewGuid(), $"admin{i}@email.com",
                    admin, "secret", "admin"));
                _logger.LogTrace($"Created a new admin: '{admin}'.");
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data has been initialized.");
        }
    }
}