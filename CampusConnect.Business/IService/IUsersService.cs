using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusConnect.Business.DTO;

namespace CampusConnect.Business.IService
{
    public interface IUsersService
    {
        Task<User> GetUserByUsername(string username);
        Task<IEnumerable<UserDTO>> GetUsersByRole(string role);
        Task<User> CreateUser(CreateUserDTO newUser);
        Task UpdateUser(UserAccountInfoDTO updateUser);
        Task DeleteUser(int userId);
        Task<bool> IsUsernameTaken(string username);
        Task<bool> IsEmailTaken(string email);
        Task<User> GetUserById(int userId);
        Task<IEnumerable<UserDTO>> SearchUsers(string searchTerm);
        Task<User> LoginUser(string username, string password);
    }
}
