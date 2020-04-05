using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EShop.Data;
using EShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EShop
{
    public class SignUpModel : PageModel
    {
        private readonly EmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public SignUpModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, EmailSender emailSender)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _emailSender = emailSender;
        }

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string FailureMessage { get; set; }
        [BindProperty]
        public RegisterInputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("./");
            if (ModelState.IsValid)
            {
                if (Input.BStreetName == null || Input.BCity == null || Input.BPostalCode == null)
                {
                    Input.BStreetName = Input.DStreetName;
                    Input.BCity = Input.DCity;
                    Input.BPostalCode = Input.DPostalCode;
                }
                var user = new ApplicationUser
                {
                    UserName = $"{Input.FirstName} {Input.LastName}",
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    DStreetName = Input.DStreetName,
                    DCity = Input.DCity,
                    DPostalCode = Input.DPostalCode,
                    BStreetName = Input.BStreetName,
                    BCity = Input.BCity,
                    BPostalCode = Input.BPostalCode,
                    PhoneNumber = Input.PhoneNumber,
                    Email = Input.Email
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var message = $"Dobrý den.<br />Děkujeme za registraci na e-shopu Tea's Create.<br />Příjemné nakupování a krásný den vám přeje Tea.";
                    await _emailSender.SendEmailAsync(Input.Email, "Potvrzení registrace", message);
                    SuccessMessage = "Registrace úspěšná";
                    return RedirectToPage("Index");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return Page();
        }
    }
    public class RegisterInputModel
    {
        [Required(ErrorMessage = "Jméno je povinný údaj")]
        [Display(Name = "Jméno *")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Příjmení je povinný údaj")]
        [Display(Name = "Příjmení *")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "E-mail je povinný údaj")]
        [Display(Name = "Email *")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Heslo je povinný údaj")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo *")]
        [StringLength(30, ErrorMessage = "Heslo musí mít délku mezi 6 a 30 znaky.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Prosím, potvrďte své heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrdit heslo *")]
        [Compare("Password", ErrorMessage = "Hesla se musí shodovat.")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Fakturační adresa - PSČ")]
        public int? BPostalCode { get; set; }
        [Display(Name = "Fakturační adresa - město")]
        public string BCity { get; set; }
        [Display(Name = "Fakturační adresa - ulice")]
        public string BStreetName { get; set; }
        [Required(ErrorMessage = "Dodací adresa je povinný údaj")]
        [Display(Name = "Dodací adresa - PSČ *")]
        public int DPostalCode { get; set; }
        [Required(ErrorMessage = "Dodací adresa je povinný údaj")]
        [Display(Name = "Dodací adresa - město *")]
        public string DCity { get; set; }
        [Required(ErrorMessage = "Dodací adresa je povinný údaj")]
        [Display(Name = "Dodací adresa - ulice *")]
        public string DStreetName { get; set; }
        [Required(ErrorMessage = "Telefonní číslo je povinný údaj")]
        [Display(Name = "Telefonní číslo *")]
        public string PhoneNumber { get; set; }
    }
}