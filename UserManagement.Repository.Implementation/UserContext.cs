using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Dtos;

namespace UserManagement.Repository
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<UserDto> user { get; set; }
    }
}
