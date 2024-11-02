using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Repository;

namespace Ass02Solution_PND.Pages.ProductPage
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _context;

        public CreateModel(IProductRepository context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        //ViewData["CategoryId"] = new SelectList(_context., "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context == null || Product == null)
            {
                return Page();
            }

            _context.AddProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}
