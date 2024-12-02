using AutoMapper;
using CampusConnect.Business.IService;
using CampusConnect.DataAccess.DataModels.CampusConnect.DataAccess.DataModels;

namespace CampusConnect.Business.Service
{
    public class UserService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork.IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork.IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(username);
            return _mapper.Map<User>(user);
        }

        public async Task<IEnumerable<User>> GetUsersByRole(string role)
        {
            var users = await _unitOfWork.UserRepository.GetUsersByRole(role);
            return _mapper.Map<IEnumerable<User>>(users);
        }

        public async Task<User> CreateUser(User newUser)
        {
            var user = _mapper.Map<User>(newUser);
            user.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.UserRepository.CreateUser(user);
            _unitOfWork.Save();

            return _mapper.Map<User>(user);
        }

        public async Task UpdateUser(int userId, User updateUser)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(updateUser.Username);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            _mapper.Map(updateUser, user);

            await _unitOfWork.UserRepository.UpdateUser(user);
            _unitOfWork.Save();
        }

        public async Task DeleteUser(int userId)
        {
            await _unitOfWork.UserRepository.DeleteUser(userId);
            _unitOfWork.Save();
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return await _unitOfWork.UserRepository.IsUsernameTaken(username);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            return await _unitOfWork.UserRepository.IsEmailTaken(email);
        }

        public async Task<IEnumerable<User>> SearchUsers(string searchTerm)
        {
            var users = await _unitOfWork.UserRepository.SearchUsers(searchTerm);
            return _mapper.Map<IEnumerable<User>>(users);
        }

        public async Task<User> LoginUser(string username, string password)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsername(username);
            if (user == null)
                throw new InvalidOperationException("Invalid username or password");

            if (!password.Equals(user.PasswordHash))
                throw new InvalidOperationException("Invalid username or password");

            return _mapper.Map<User>(user);
        }
    }
}
