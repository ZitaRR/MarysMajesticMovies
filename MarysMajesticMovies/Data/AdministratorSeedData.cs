using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies.Data
{
    public class AdministratorSeedData
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public AdministratorSeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("admin@admin.com") == null)
            {
                User administrator = new User()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "Adminsson",
                    Address = "Administreet",
                    ZipCode = 12345,
                    City = "Administan",
                    PhoneNumber = "070000000"
                };

                await _userManager.CreateAsync(administrator, "Passw0rd123!");
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));

                await _userManager.AddToRoleAsync(administrator, "Administrator");
            }
        }
    }
}
