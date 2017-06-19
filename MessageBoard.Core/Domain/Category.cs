using System;

namespace MessageBoard.Core.Domain
{
    public class Category
    {
        public string Type { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected Category(string type, string name, string description)
        {
            SetType(type);
            SetName(name);
            SetDescription(description);
        }

        protected Category()
        {
        }

        private void SetType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new Exception("Type name can not be empty.");
            }
            if (Name == type)
            {
                return;
            }
            Type = type;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Category name can not be empty.");
            }
            if (Name == name)
            {
                return;
            }
            Name = name;
        }

        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Description can not be empty.");
            }
            if (Description == description)
            {
                return;
            }
            Description = description;
        }

        public static Category Create(string type, string name, string description)
            => new Category(type, name, description);
    }
}
