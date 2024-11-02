using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repository;

namespace Ass02Solution_PND.Pages.ProductPage
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public EditModel(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0 || _productRepo == null)
            {
                return NotFound();
            }

            Product =  _productRepo.GetProduct(id);
            if (Product == null)
            {
                return NotFound();
            }

            //ViewData["CategoryId"] = new SelectList( _categoryRepo.GetAllCategories(), "CategoryId", "CategoryName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Populate category list again if there are validation errors
                //ViewData["CategoryId"] = new SelectList( _categoryRepo.GetAllCategories(), "CategoryId", "CategoryName", Product.CategoryId);
                return Page();
            }

            try
            {
                var existingP = _productRepo.GetProduct(Product.Id);

                if (existingP != null)
                {
                    existingP.Price = Product.Price;
                    existingP.Description = Product.Description;
                    existingP.Name = Product.Name;


                    _productRepo.UpdateProduct(existingP);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> ProductExists(int id)
        {
            return  _productRepo.GetProduct(id) != null;
        }
    }
}
