using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Model;
using UserManagement.Repository;
using UserManagement.Shared.Contracts;

namespace UserManagement.Shared.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly UserContext _context;

        public UserManager(UserContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            var userDto = user.ToUserDto();
            _context.user.Add(userDto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var userEntity = await _context.user.FindAsync(userId);
            if (userEntity != null)
            {
                _context.user.Remove(userEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditUserAsync(UserDto userDto)
        {
            var userEntity = await _context.user.FindAsync(userDto.Id);
            if (userEntity != null)
            {
                userEntity.Name = userDto.Name;
                userEntity.Email = userDto.Email;
                userEntity.Role = userDto.Role;

                _context.user.Update(userEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserDto>> GetUserAsync()
        {
            var users = await _context.user.ToListAsync();
            return users;
        }
    }
}
