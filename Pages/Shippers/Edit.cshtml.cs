using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindIaroslav.Models;
using Northwindiaroslav.Data;

namespace NorthwindIaroslav.Pages.Shippers
{
    public class EditModel : PageModel
    {
        private readonly Northwindiaroslav.Data.NorthwindIaroslavSQLiteContext _context;

        public EditModel(Northwindiaroslav.Data.NorthwindIaroslavSQLiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shipper Shipper { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipper =  await _context.Shippers.FirstOrDefaultAsync(m => m.ShipperID == id);
            if (shipper == null)
            {
                return NotFound();
            }
            Shipper = shipper;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shipper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipperExists(Shipper.ShipperID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShipperExists(int id)
        {
            return _context.Shippers.Any(e => e.ShipperID == id);
        }
    }
}
