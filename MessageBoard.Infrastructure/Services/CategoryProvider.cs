using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Core.Domain;
using MessageBoard.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace MessageBoard.Infrastructure.Services
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "Categories";
        private static readonly IDictionary<string, IEnumerable<Subcategory>> AvailableCategories =
            new Dictionary<string, IEnumerable<Subcategory>>
            {
                ["Food"] = new List<Subcategory>
                {
                    new Subcategory("Healthy food", "Thousands of delicious healthy recipes."),
                    new Subcategory("Grilled food", "Best recipes for grilling and summer outdoor cookouts.")
                },
                ["Motoring"]  = new List<Subcategory>
                {
                    new Subcategory("Motorcycles", "We know that for most riders, motorcycles are a way of life."),
                    new Subcategory("Cars", "Research and compare cars, find local dealers/sellers and much more."),
                    new Subcategory("Airplanes", "This is the place to discuss unusual aircraft.")
                },
                ["Sport"] = new List<Subcategory>
                {
                    new Subcategory("Football", "News, results, fixtures, blogs, podcasts and comment on World football"),
                    new Subcategory("Snooker", "The place to go forthe latest snooker results and rankings.")
                },
                ["Video games"] = new List<Subcategory>
                {
                    new Subcategory("PC", "Find the hottest PC gaming gear including computers, accessories," +
                                          " components, games, and more."),
                    new Subcategory("Console", "The video game console realm is much bigger than the heavily" +
                                               " marketed Xbox One and Sony Playstation 4 suggest.")
                }
            };

        public CategoryProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<IEnumerable<CategoryDto>> BrowseAsync()
        {
            var categories = _cache.Get<IEnumerable<CategoryDto>>(CacheKey);
            if (categories != null)
            {
                return categories;
            }
            categories = await GetAllAsync();
            _cache.Set(CacheKey, categories);
            return categories;
        }

        public async Task<CategoryDto> GetAsync(string type, string name)
        {
            if (!AvailableCategories.ContainsKey(type))
            {
                throw new Exception($"Category type: {type} is not available.");
            }
            var categories = AvailableCategories[type];
            var category = categories.SingleOrDefault(x => x.Name == name);
            if(category == null)
            {
                throw new Exception($"Category: {name} for type: {type} is not available.");
            }
            return await Task.FromResult(new CategoryDto
            {
                Type = type,
                Name = name,
                Description = category.Description
            });
        }

        //mozliwe bledne zapytanie Linq
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
            => await Task.FromResult(AvailableCategories.GroupBy(x => x.Key)
                .SelectMany(g => g.SelectMany(c => c.Value.Select(v => new CategoryDto
                {
                    Name = v.Name,
                    Description = v.Description
                }))));

        private class Subcategory
        {
            public string Name { get; set; }
            public string Description { get; set; }

            public Subcategory(string name, string description)
            {
                Name = name;
                Description = description;
            }
        }
    }
}
