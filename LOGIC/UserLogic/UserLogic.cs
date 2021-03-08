using BASE.Models;
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

        private HttpResult httpResult = new HttpResult();

        // Add a new user
        public async Task<HttpResult> CreateNewUser(UserViewModel userObj)
        {
            try
            {
                var result = await _user.AddUser(userObj);
                if (result.Id > 0)
                {
                    httpResult.success = true;
                    httpResult.data = result;
                    httpResult.message = "Succesfully added user";
                    return httpResult;
                }
                else
                {
                    httpResult.success = false;
                    httpResult.data = result;
                    httpResult.message = "Failed to add user, Username/Email exists";
                    return httpResult;
                }
            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - CreateNewUser" };
            }
        }

        // Get all users
        public async Task<HttpResult> GetAllUsers()
        {

            try
            {
                List<UserViewModel> users = await _user.GetAllUsers();

                if (users.Count > 0)
                {
                    httpResult.success = true;
                    httpResult.data = users;
                    httpResult.message = "Succesfully retreive all users, Count: " + users.Count.ToString();
                    return httpResult;
                }
                else
                {
                    httpResult.success = false;
                    httpResult.data = users;
                    httpResult.message = "Failed to retreive all usersr";
                    return httpResult;
                }
            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - GetAllUsers" };
            }
        }

        // Authenticate a user
        public HttpResult Authenticate(UserViewModel userObj)
        {

            try
            {

                string token = _user.Authenticate(userObj);

                if( token == null )
                {
                    httpResult.success = false;
                    httpResult.data = null;
                    httpResult.message = "Failed to called Auth";
                    return httpResult;
                } else
                {
                    httpResult.success = true;
                    httpResult.data = token;
                    httpResult.message = "Succesfully called Auth";
                    return httpResult;
                }

            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - GetAllUsers" };
            }
        }

    }
}
