using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myshop.Entities.Models;
using myshop.Utilities;

namespace myshop.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public DbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            //Migrations
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _dbContext.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }


            //Roles
            if (!_roleManager.RoleExistsAsync(SD.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.EditorRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.CustomerRole)).GetAwaiter().GetResult();

                //User 
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Admin",
                    Address = "Cairo",
                    City = "Cairo",
                }, "Admin@123").GetAwaiter().GetResult();
                ApplicationUser user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, SD.AdminRole).GetAwaiter().GetResult();

            }
            return;
        }
    }
}
