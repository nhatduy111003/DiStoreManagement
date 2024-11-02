using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DAOs;
using Repository;

namespace Ass02Solution_PND.Pages.AdminPage
{
    public class DeleteModel : PageModel
    {
        private readonly IUserRepository userRepo;

        public DeleteModel()
        {
            userRepo = new UserRepository();
        }

        [BindProperty]
        public userContext userContext { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || userRepo == null)
            {
                return NotFound();
            }

            var user = userRepo.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                userContext = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || userRepo == null)
            {
                return NotFound();
            }
            var user = userRepo.GetUser(id);

            if (user != null)
            {
                userRepo.DeleteUser(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
