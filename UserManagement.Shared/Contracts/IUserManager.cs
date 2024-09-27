using UserManagement.Domain.Dtos;
using UserManagement.Domain.Model;

namespace UserManagement.Shared.Contracts
{
    public interface IUserManager
    {
        Task AddUserAsync(User userDto);
        Task<List<UserDto>> GetUserAsync();
        Task EditUserAsync(UserDto userDto);
        Task DeleteUserAsync(Guid userId);
    }
}
