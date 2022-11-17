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
    public class DetailsModel : PageModel
    {
        private readonly Gardentools.Data.GardentoolsContext _context;

        public DetailsModel(Gardentools.Data.GardentoolsContext context)
        {
            _context = context;
        }

      public Basket Basket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Basket == null)
            {
                return NotFound();
            }

            var basket = await _context.Basket.FirstOrDefaultAsync(m => m.Id == id);
            if (basket == null)
            {
                return NotFound();
            }
            else 
            {
                Basket = basket;
            }
            return Page();
        }
    }
}
