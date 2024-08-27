using Jus_365.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

public static class ApplicationDbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        Console.WriteLine($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@Exception during initializatio 1");

        using (var scope = serviceProvider.CreateScope())
        {
            Console.WriteLine($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@Exception during initializatio 2");

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string userEmail = "moraes.luishenrique17@gmail.com";
            string roleName = "Admin";
            Console.WriteLine($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@Exception during initializatio 3");

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    // Log or handle the errors
                    foreach (var error in result.Errors)
                    {
                        // Log each error
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
            }
            Console.WriteLine($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@Exception during initializatio 4");

            var user = await userManager.FindByEmailAsync(userEmail);

            if (user == null)
            {
                user = new ApplicationUser { UserName = userEmail, Email = userEmail,EmailConfirmed = true };
                var result = await userManager.CreateAsync(user, "Agatha28022020@");
                if (!result.Succeeded)
                {
                    // Log or handle the errors
                    foreach (var error in result.Errors)
                    {
                        // Log each error
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
                if (result.Succeeded)
                {
                   var result2 = await userManager.AddToRoleAsync(user, roleName);
                    if (!result2.Succeeded)
                    {
                        // Log or handle the errors
                        foreach (var error in result2.Errors)
                        {
                            // Log each error
                            Console.WriteLine($"Error: {error.Description}");
                        }
                    }
                }
                Console.WriteLine($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@Exception during initializatio 5");
            }
          

            else
            {
                if (!await userManager.IsInRoleAsync(user, roleName))
                {
                 var result3=   await userManager.AddToRoleAsync(user, roleName);

                    if (!result3.Succeeded)
                    {
                        // Log or handle the errors
                        foreach (var error in result3.Errors)
                        {
                            // Log each error
                            Console.WriteLine($"Error: {error.Description}");
                        }
                    }
                }
                Console.WriteLine($"@@@@@@@@@@@@@@@@@@@@@@@@@@@@Exception during initializatio 6");

            }
        }
    }
}
