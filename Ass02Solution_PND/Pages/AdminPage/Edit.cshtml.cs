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

namespace Ass02Solution_PND.Pages.AdminPage
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository userRepo;

        public EditModel()
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
            userContext = user;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var existingUser = userRepo.GetUser(userContext.Id);

                if (existingUser != null)
                {
                    existingUser.Username = userContext.Username; 
                    existingUser.Role = userContext.Role;
                    existingUser.Email = userContext.Email;
                    existingUser.Password = userContext.Password;
                
                    userRepo.UpdateUser(existingUser);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userContext.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(int id)
        {
            bool isSuccess = false;
            try
            {
                var userExist = userRepo.GetUser(id);
                if (userExist != null)
                    isSuccess = true;
            }
            catch (Exception)
            {

                throw;
            }
            return isSuccess;
        }
    }
}
