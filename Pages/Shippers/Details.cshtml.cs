using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindIaroslav.Models;
using Northwindiaroslav.Data;

namespace NorthwindIaroslav.Pages.Shippers
{
    public class DetailsModel : PageModel
    {
        private readonly Northwindiaroslav.Data.NorthwindIaroslavSQLiteContext _context;

        public DetailsModel(Northwindiaroslav.Data.NorthwindIaroslavSQLiteContext context)
        {
            _context = context;
        }

        public Shipper Shipper { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipper = await _context.Shippers.FirstOrDefaultAsync(m => m.ShipperID == id);
            if (shipper == null)
            {
                return NotFound();
            }
            else
            {
                Shipper = shipper;
            }
            return Page();
        }
    }
}
