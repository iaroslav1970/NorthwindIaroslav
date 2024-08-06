using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindIaroslav.Models;
using Northwindiaroslav.Data;

namespace NorthwindIaroslav.Pages.Shippers
{
    public class CreateModel : PageModel
    {
        private readonly Northwindiaroslav.Data.NorthwindIaroslavSQLiteContext _context;

        public CreateModel(Northwindiaroslav.Data.NorthwindIaroslavSQLiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shipper Shipper { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shippers.Add(Shipper);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
