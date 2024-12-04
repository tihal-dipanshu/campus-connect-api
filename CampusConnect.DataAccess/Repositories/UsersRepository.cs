using Microsoft.EntityFrameworkCore;
using CampusConnect.DataAccess.IRepositories;
using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

namespace CampusConnect.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CampusConnectContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersByRole(string role)
        {
            return await Context.Users.Where(u => u.UserRole == role).ToListAsync();
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await Context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await Context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> CreateUser(User user)
        {
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await Context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.UserRole = user.UserRole;

                Context.Users.Update(existingUser);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int userId)
        {
            var user = await Context.Users.FindAsync(userId);
            if (user != null)
            {
                Context.Users.Remove(user);
                await Context.SaveChangesAsync();
            }
        }
        
        public async Task<User> GetUserById(int userId)
        {
            return await Context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
        }

        public async Task<IEnumerable<User>> SearchUsers(string searchTerm)
        {
            return await Context.Users
                .Where(u => u.Username.Contains(searchTerm) ||
                            u.Email.Contains(searchTerm) ||
                            u.FirstName.Contains(searchTerm) ||
                            u.LastName.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
