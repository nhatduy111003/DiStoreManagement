using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using DataAccess.Repository;
using Repository;

namespace Ass02Solution_PND.Pages
{
    public class LoginModel : PageModel
    {
        private IUserRepository userRepo;

        public LoginModel()
        {
            userRepo = new UserRepository();
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string email = Request.Form["txtEmail"];
            string passWord = Request.Form["txtPassword"];

            userContext user = userRepo.GetUser(email);
            if (user != null && user.Password.Equals(passWord) && user.Role.Equals("manager"))
            {
                Response.Redirect("/ProductPage/Index");
            }
            else if (user != null && user.Password.Equals(passWord) && user.Role.Equals("admin"))
            {
                Response.Redirect("/AdminPage/Index");
            }
            else if (user != null && user.Password.Equals(passWord) && user.Role.Equals("customer"))
            {
                Response.Redirect("/UserPage/Index");
            }




        }
    }
}
