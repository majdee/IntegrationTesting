using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using UserManagementAPI.Controllers.ViewModels;
using UserManagementAPI.Entities;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManagementDbContext _dbContext;

        public UsersController(UserManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task Post([FromBody] UserViewModel userViewModel)
        {
            if(userViewModel == null)
                throw new ArgumentException("Invalid input!");

            var existingUser =await _dbContext.Users.FirstOrDefaultAsync(
                u => string.Equals(u.UserName.ToLower(), userViewModel.UserName, StringComparison.InvariantCultureIgnoreCase));

            if (existingUser != null)
            {
                existingUser.FullName = userViewModel.FullName;
            }
            else
            {
                await _dbContext.AddAsync(new User
                {
                    UserName = userViewModel.UserName,
                    FullName = userViewModel.FullName
                });
            }

            await _dbContext.SaveChangesAsync();

        }
    }
}
