using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindIaroslav.Models;
using Northwindiaroslav.Data;

namespace NorthwindIaroslav.Pages.OrderDetails
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
        ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderID");
        ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            return Page();
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
