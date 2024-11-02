using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Repository;

namespace Ass02Solution_PND.Pages.AdminPage
{
    public class CreateModel : PageModel
    {
        private readonly IUserRepository userRepo;

        public CreateModel()
        {
            userRepo = new UserRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public userContext userContext { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || userRepo == null || userContext == null)
            {
                return Page();
            }

            userRepo.AddUser(userContext);

            return RedirectToPage("./Index");
        }
    }
}
