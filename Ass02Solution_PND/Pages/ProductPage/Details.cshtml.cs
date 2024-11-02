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
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository productRepo;
        private readonly ICategoryRepository categoryRepo;

        public DetailsModel()
        {
            productRepo = new ProductRepository();
            categoryRepo = new CategoryRepository();
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || productRepo == null)
            {
                return NotFound();
            }

            var product = productRepo.GetProduct(id);
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
    }
}
