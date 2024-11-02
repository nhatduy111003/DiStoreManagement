using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repository;

namespace Ass02Solution_PND.Pages.ProductPage
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository ProductRepo;

        public DeleteModel()
        {
            ProductRepo = new ProductRepository();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || ProductRepo == null)
            {
                return NotFound();
            }

            var product = ProductRepo.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || ProductRepo == null)
            {
                return NotFound();
            }
            var product = ProductRepo.GetProduct(id);

            if (product != null)
            {
                ProductRepo.DeleteProduct(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
