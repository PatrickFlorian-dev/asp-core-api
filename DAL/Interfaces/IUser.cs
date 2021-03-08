using core_api.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser
    {
        Task<User> AddUser(UserViewModel userObj);
        Task<List<UserViewModel>> GetAllUsers();

        bool Authenticate();
    }
}
