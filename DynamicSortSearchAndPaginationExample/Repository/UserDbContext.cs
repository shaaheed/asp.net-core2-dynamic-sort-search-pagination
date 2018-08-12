using DynamicFilterAndPaginationExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicFilterAndPaginationExample.Repository
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

    }
}
