using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LOGIC.UserLogic;

namespace core_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private UserLogic userLogic = new UserLogic();

        // GET api/user
        [HttpGet]
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            var users = await userLogic.GetAllUsers();
            if(users.Count > 0 )
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
                        UpdatedAt = user.UpdatedAt,
                    };
                    userList.Add(currentUser);
                };
            }

            return userList;

        }

        // GET api/user/adduser
        [HttpGet("adduser/{username}/{emailAddress}/{firstName}/{lastName}/{password}/{authLevelId}")]
        // Add a new user *** NOTE: passing these params in via a url for now just to quickly demo DB, will switch to passing object and POST request in next branch ***
        // API for quick demo would look like this https://localhost:44366/api/user/adduser/testUserName/testEmail/TestFName/TestLName/TestPassword/1
        public async Task<Boolean> AddUser(string username, string emailAddress, string firstName, string lastName, string password, int authLevelId)
        {
            // Add Logic to check if username exists
            // Add logic to encrypt password
            // Add logic to return more robust object instead of boolean
            bool result = await userLogic.CreateNewUser(username, emailAddress, firstName, lastName, password, authLevelId);
            return result;
        }

    }
}
