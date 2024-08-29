using Jus_365.Models;
using Microsoft.AspNetCore.Identity;

public interface IMenuService
{
    Task<IEnumerable<MenuItem>> GetMenuItemsAsync(ApplicationUser user);
}

public class MenuService : IMenuService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public MenuService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItemsAsync(ApplicationUser user)
    {
        if (user == null)
        {
            // Retorne um menu padrão ou vazio
            return new List<MenuItem>();
        }
        var roles = await _userManager.GetRolesAsync(user);
        var menuItems = new List<MenuItem>();
        if (roles.Contains("Admin"))
        {
            menuItems.Add(new MenuItem { Name = "Usuários", Url = "/Users" });
            menuItems.Add(new MenuItem { Name = "Roles", Url = "/Role" });
            menuItems.Add(new MenuItem { Name = "Planos", Url = "/Planos" });
            menuItems.Add(new MenuItem { Name = "Empresas", Url = "/Empresas" });
            menuItems.Add(new MenuItem { Name = "Menu", Url = "/Menu" });
            menuItems.Add(new MenuItem { Name = "Nodes", Url = "/NodeItem" });





        }

        if (roles.Contains("User"))
        {
            menuItems.Add(new MenuItem { Name = "User Profile", Url = "/User/Profile" });
        }

        return menuItems;
    }
}

public class MenuItem
{
    public string Name { get; set; }
    public string Url { get; set; }
}
