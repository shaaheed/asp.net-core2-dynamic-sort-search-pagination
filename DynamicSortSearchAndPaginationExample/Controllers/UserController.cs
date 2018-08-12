using System.Collections.Generic;
using System.Linq;
using DynamicFilterAndPaginationExample.Infrastructure;
using DynamicFilterAndPaginationExample.Models;
using DynamicFilterAndPaginationExample.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DynamicFilterAndPaginationExample.Controllers
{
    [Route("api")]
    public class UserController : Controller
    {

        // GET api/values
        [HttpGet("users")]
        public IEnumerable<User> Get(
            [FromQuery] SortOptions sortOptions,
            [FromQuery] PagingOptions pagingOptions,
            [FromQuery] SearchOptions searchOptions)
        {

            var users = new List<User> {
                new User { Id = 1, Name = "Shahid", Email = "shahid@gmail.com", UserStatusId = 1 },
                 new User { Id = 4, Name = "Shahid", Email = "abc@gmail.com", UserStatusId = 1 },
                new User { Id = 2, Name = "Islam", Email = "islam@gmail.com", UserStatusId = 1 },
                new User { Id = 3, Name = "Msi", Email = "msi@gmail.com", UserStatusId = 2 },
            }.AsQueryable();

            users = users.ApplyPagination(pagingOptions);
            users = users.ApplySort(sortOptions);
            users = users.ApplySearch(searchOptions);
            return users;
        }

    }
}
