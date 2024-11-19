using CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetUsersByRole(string role);
        Task<bool> IsUsernameTaken(string username);
        Task<bool> IsEmailTaken(string email);
        Task<User> CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
        Task<IEnumerable<User>> SearchUsers(string searchTerm);
    }
}
