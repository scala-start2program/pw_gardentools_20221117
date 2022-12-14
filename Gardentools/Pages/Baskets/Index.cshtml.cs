using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gardentools.Data;
using Gardentools.Models;

namespace Gardentools.Pages.Baskets
{
    public class IndexModel : PageModel
    {
        private readonly Gardentools.Data.GardentoolsContext _context;

        public IndexModel(Gardentools.Data.GardentoolsContext context)
        {
            _context = context;
        }

        public IList<Basket> Basket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Basket != null)
            {
                Basket = await _context.Basket
                .Include(b => b.Article)
                .Include(b => b.User).ToListAsync();
            }
        }
    }
}
