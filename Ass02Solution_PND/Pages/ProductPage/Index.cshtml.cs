using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repository;
using BusinessObject.DTO;

namespace Ass02Solution_PND.Pages.ProductPage
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _context;

        public IndexModel(IProductRepository context)
        {
            _context = context;
        }

        public IList<ProductDTO> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context != null)
            {
                Product = _context.GetProducts();
            }
        }
    }
}
