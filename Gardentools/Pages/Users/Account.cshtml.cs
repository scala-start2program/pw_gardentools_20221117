using Gardentools.Helpers;
using Gardentools.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gardentools.Pages.Users
{
    public class AccountModel : PageModel
    {
        private readonly Gardentools.Data.GardentoolsContext _context;
        public User User { get; set; }
        public Availability Availability { get; set; }

        public AccountModel(Gardentools.Data.GardentoolsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Availability = new Availability(_context, HttpContext);
            if (string.IsNullOrEmpty(Availability.UserId))
            {
                return NotFound();
            }
            int id = int.Parse(Availability.UserId);

            User = _context.User.FirstOrDefault(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}
