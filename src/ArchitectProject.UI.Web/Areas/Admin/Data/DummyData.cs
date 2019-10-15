using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectProject.UI.Web.Areas.Admin.Data
{
    public class DummyData
    {
        public static async Task Initialize(APContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            string role1 = "Admin";
            string desc1 = "Perfil de Administrador";

            string role2 = "Membro";
            string desc2 = "Perfil de Membro";

            string password = "@Mudar123";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("leandro") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "leandro",
                    Email = "leandro.rovagnoli@gmail.com",
                    FirstName = "Leandro",
                    LastName = "Rovagnoli",
                    Street = "Rua Fake, 55",
                    City = "São Paulo",
                    State = "SP",
                    PostalCode = "02752000",
                    Country = "Brasil",
                    PhoneNumber = "11980798740",
                    RegistrationDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
            }

            if (await userManager.FindByNameAsync("eduardo") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "eduardo",
                    Email = "edufdctv@gmail.com",
                    FirstName = "Eduardo",
                    LastName = "Fernandes",
                    Street = "Rua Copacabana, 10",
                    City = "São Paulo",
                    State = "SP",
                    PostalCode = "02752000",
                    Country = "Brasil",
                    PhoneNumber = "11998795401",
                    RegistrationDate = DateTime.Now
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role2);
                }
            }
        }
    }
}
