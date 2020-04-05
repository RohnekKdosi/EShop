using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EShop.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop
{
    public class SignInModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public SignInModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            Input = new LoginInputModel();
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string FailureMessage { get; set; }

        public async Task OnGet(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            await HttpContext.SignOutAsync();
            Input.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user != null)
                {
                    var result = await _signinManager.PasswordSignInAsync(user.UserName, Input.Password, Input.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Přihlášení selhalo");
                        return Page();
                    }
                }
                else
                {
                    FailureMessage = "Uživatel nenalezen";
                    return Page();
                }
            }
            return Page();
        }
    }
    public class LoginInputModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Heslo")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        [Display(Name = "Zapamatovat si mě")]
        public bool RememberMe { get; set; }
    }
}