using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repository;

namespace Ass02Solution_PND.Pages.AdminPage
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _context;

        public IndexModel(IUserRepository context)
        {
            _context = context;
        }

        public IList<userContext> userContext { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context != null)
            {
                userContext =  _context.GetAllUsers();
            }
        }
    }
}
