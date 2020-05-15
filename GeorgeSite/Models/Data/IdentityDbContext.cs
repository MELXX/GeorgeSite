using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeorgeSite.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeorgeSite.Models.Data
{
    public class IdentityDbContext: IdentityDbContext<IdentityUser>
    {
        DbContextOptions<IdentityDbContext> _options;
        public DbSet<GeorgeSite.Models.Entities.User> User { get; set; }
        public IdentityDbContext(DbContextOptions<IdentityDbContext> _options) : base(_options)
        {
            this._options = _options;
        }

        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
    IConfiguration configuration)
        {
            UserManager<IdentityUser> userManager =
                serviceProvider.GetRequiredService<UserManager<IdentityUser>>();  //dependency injection
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();  //dep inj
            string username = configuration["Data:AdminUser:UserName"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];
            string email = configuration["Data:AdminUser:Email"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                IdentityUser user = new IdentityUser
                {
                    UserName = username,
                    Email = email 
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

        }//end of admin seeding
    }
}
