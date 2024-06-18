using System;
using System.Collections.Generic;

namespace CRUD_application_2.Models
{
    public class UserInitializer
    {
        public static List<User> InitializeUsers()
        {
            var random = new Random();
            var users = new List<User>
            {
                new User { Id = random.Next(1, 1000), Name = "Alice", Email = "alice@example.com" },
                new User { Id = random.Next(1, 1000), Name = "Bob", Email = "bob@example.com" },
                new User { Id = random.Next(1, 1000), Name = "Charlie", Email = "charlie@example.com" },
                new User { Id = random.Next(1, 1000), Name = "Diana", Email = "diana@example.com" },
                new User { Id = random.Next(1, 1000), Name = "Evan", Email = "evan@example.com" }
            };

            return users;
        }
    }
}
