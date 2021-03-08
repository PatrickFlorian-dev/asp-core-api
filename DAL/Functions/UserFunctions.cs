using core_api.Models;
using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class UserFunctions : IUser
    {
        private DatabaseContext dbContext = new DatabaseContext(DatabaseContext.ops.dbOptions);
        // Add a new user
        public async Task<User> AddUser(UserViewModel userObj)
        {
            User checkUserExists = dbContext.Users
              .Where(u => u.Email.ToLower() == userObj.EmailAddress).FirstOrDefault();

            if( checkUserExists != null ) { return new User(); }

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

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return newUser;
        }

        // Get all users
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<User> users = new List<User>();
            users = await dbContext.Users.ToListAsync();
            List<UserViewModel> userList = new List<UserViewModel>();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    UserViewModel currentUser = new UserViewModel
                    {
                        AuthLevel = user.AuthLevelRefId,
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmailAddress = user.Email,
                        CreatedAt = user.CreatedAt,
                        UpdatedAt = user.UpdatedAt
                    };
                    userList.Add(currentUser);
                };
            }

            return userList;
        }

        // Authenticate a user
        public /*async*/ bool Authenticate()
        {
            return true;
        }
    }
}
