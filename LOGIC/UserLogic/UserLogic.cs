using core_api.Models;
using DAL.Entities;
using DAL.Functions;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.UserLogic
{
    public class UserLogic
    {
        private IUser _user = new UserFunctions();

        // Add a new user
        public async Task<Boolean> CreateNewUser(UserViewModel userObj)
        {
            try
            {
                var result = await _user.AddUser(userObj);
                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.Write(error);
                return false;
            }
        }

        // Get all users
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await _user.GetAllUsers();
            return users;
        }

    }
}
