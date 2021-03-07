using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser
    {
        Task<User> AddUser(string username, string emailAddress, string firstName, string lastName, string password, int authLevelId);
        Task<List<User>> GetAllUsers();
    }
}
