using UserManagement.Domain.Dtos;

namespace UserManagement.Domain.Model
{
    public static class UserExtensions
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto()
            {
                Id = Guid.NewGuid(),
                Email = user.Email,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}
