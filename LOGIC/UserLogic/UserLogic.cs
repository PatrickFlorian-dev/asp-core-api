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
            List<UserViewModel> users = await _user.GetAllUsers();

            try
            {
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

        // Authenticat a user
        public async Task<HttpResult> Authenticate()
        {
            bool auth = _user.Authenticate();

            try
            {

                httpResult.success = true;
                httpResult.data = auth;
                httpResult.message = "Succesfully called Auth";
                return httpResult;

            }
            catch (Exception error)
            {
                return new HttpResult { success = false, data = error, message = "API failed - GetAllUsers" };
            }
        }

    }
}
