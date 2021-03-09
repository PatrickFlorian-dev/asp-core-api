using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LOGIC.UserLogic;
using core_api.Common;
using core_api.Models;
using BASE.Models;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace core_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserLogic userLogic = new UserLogic();

        // GET api/user
        [HttpGet]
        public async Task<HttpResult> GetAllUsers()
        {
            var users = await userLogic.GetAllUsers();
            return users;

        }

        // POST api/user/adduser
        [AllowAnonymous] // Allow an unauthed user to add themselves
        [HttpPost("adduser")]
        public async Task<HttpResult> AddUser(UserViewModel userObj)
        {
            HttpResult result = await userLogic.CreateNewUser(userObj);
            return result;
        }

        // POST api/user/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public HttpResult Authenticate(UserViewModel userObj)
        {
            HttpResult result = userLogic.Authenticate(userObj);
            return result;
        }

    }
}
