using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.Business.IService
{
    public interface IUsersService
    {
        Task<User> GetUserByUsername(string username);
        Task<IEnumerable<User>> GetUsersByRole(string role);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(int userId, User updateUser);
        Task DeleteUser(int userId);
        Task<bool> IsUsernameTaken(string username);
        Task<bool> IsEmailTaken(string email);
        Task<IEnumerable<User>> SearchUsers(string searchTerm);
        Task<User> LoginUser(string username, string password);
    }
}
