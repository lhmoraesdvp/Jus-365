using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jus_365.Models
{
    public class UserWithRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public IEnumerable<string> CurrentRoles { get; set; }
        public IEnumerable<SelectListItem> AvailableRoles { get; set; }
        public IList<string> SelectedRoles { get; set; }
    }
}
