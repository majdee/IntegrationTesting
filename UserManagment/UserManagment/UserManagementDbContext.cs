using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Entities;

namespace UserManagementAPI
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}