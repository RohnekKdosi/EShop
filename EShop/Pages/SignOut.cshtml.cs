using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop.Pages
{
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignOutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl)
        {
            await _signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
    }
}