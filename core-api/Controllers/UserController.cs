using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LOGIC.UserLogic;
using core_api.Common;
using core_api.Models;

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
                        UpdatedAt = user.UpdatedAt
                    };
                    userList.Add(currentUser);
                };
            }

            return userList;

        }

        // POST api/user/adduser
        [HttpPost("adduser")]
        public async Task<Boolean> AddUser(UserViewModel userObj)
        {
            // Add Logic to check if username exists
            // Add logic to encrypt password
            // Add logic to return more robust object instead of boolean
            bool result = await userLogic.CreateNewUser(userObj);
            return result;
        }

    }
}
