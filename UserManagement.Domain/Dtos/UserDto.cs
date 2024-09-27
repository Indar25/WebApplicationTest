using UserManagement.Domain.Model;

namespace UserManagement.Domain.Dtos
{
    public class UserDto : User
    {
        public Guid Id { get; set; }
    }
}
