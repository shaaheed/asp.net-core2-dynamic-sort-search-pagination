using DynamicFilterAndPaginationExample.Models;
using System.Collections.Generic;

namespace DynamicFilterAndPaginationExample.Repository
{
    public class DataSeeder
    {

        private readonly UserDbContext _userDbContext;

        public DataSeeder(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public void Seed()
        {

            _userDbContext.UserStatuses.AddRange(new List<UserStatus>
            {
                new UserStatus { Id = 1, Status = "Active" },
                new UserStatus { Id = 2, Status = "Inactive" }
            });

            _userDbContext.AddressTypes.AddRange(new List<AddressType>
            {
                new AddressType { Id = 1, Type = "Primary" },
                new AddressType { Id = 2, Type = "Secondary" }
            });

            _userDbContext.Addresses.AddRange(new List<Address>
            {
                new Address { Id = 1, AddressTypeId = 1, Street = "Dhaka" },
                new Address { Id = 2, AddressTypeId = 1, Street = "Mirpur" },
                new Address { Id = 3, AddressTypeId = 2, Street = "Mohakhali" }
            });

            _userDbContext.Users.AddRange(new List<User>
            {
                new User { Id = 1, Name = "Shahid", Email = "shahid@gmail.com", UserStatusId = 1 },
                new User { Id = 2, Name = "Islam", Email = "islam@gmail.com", UserStatusId = 1 },
                new User { Id = 3, Name = "Msi", Email = "msi@gmail.com", UserStatusId = 2 },
            });

            _userDbContext.UserAddresses.AddRange(new List<UserAddress>
            {
                new UserAddress { Id = 1, UserId = 1, AddressId = 1 },
                new UserAddress { Id = 2, UserId = 2, AddressId = 1 },
                new UserAddress { Id = 3, UserId = 3, AddressId = 2 },
            });

            _userDbContext.SaveChanges();

        }

    }
}
