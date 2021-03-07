using core_api.Models;
using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class UserFunctions : IUser
    {
        // Add a new user
        public async Task<User> AddUser(UserViewModel userObj)
        {
            User newUser = new User
            {
                Email = userObj.EmailAddress,
                Password = userObj.Password,
                Username = userObj.Username,
                FirstName = userObj.FirstName,
                LastName = userObj.LastName,
                AuthLevelRefId = userObj.AuthLevel,
                // TODO: Create a constructor or override saveAsync method to inspect and automatically add this property going forward
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.Users.AddAsync(newUser);
                await context.SaveChangesAsync();
            }
            return newUser;
        }

        // Get all users
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                users = await context.Users.ToListAsync();
            }
            return users;
        }
    }
}
