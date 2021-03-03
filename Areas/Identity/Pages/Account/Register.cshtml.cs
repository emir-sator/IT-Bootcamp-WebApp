using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EnumsNET;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using Enums = RS1SeminarskiRad2020.Data.Enums;



namespace RS1SeminarskiRad2020.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel 
    {

        private readonly ApplicationDbContext db;
       
       
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly UserManager<Korisnik> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<Korisnik> userManager,
            SignInManager<Korisnik> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, ApplicationDbContext _db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            db = _db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public int tipId { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public object EntityData { get; private set; }

       

        public class InputModel
        {
            
            [Required]
            [StringLength(50, ErrorMessage = "Mora biti najmanje jedan znak i maksimalno 50!", MinimumLength = 2)]
            [Display(Name = "Ime")]
            public string Ime { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "Mora biti najmanje jedan znak i maksimalno 50!", MinimumLength = 2)]
            [Display(Name = "Prezime")]
            public string Prezime { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "Mora biti najmanje tri znaka", MinimumLength = 2)]
            [Display(Name = "Grad")]
            public string Grad { get; set; }
            
            [RegularExpression("^[0-9A-Za-z ]+$", ErrorMessage ="Adresa mora sadržavati samo brojeve i karaktere!")]
            [Display(Name = "Adresa")]
            public string Adresa { get; set; }

            [Required]
            [RegularExpression("[0-9]+", ErrorMessage = "Broj telefona mora sadržavati samo brojeve!")]
            [StringLength(10, ErrorMessage = "Broj mora imati najmanje 9 a najvise 10 cifara!", MinimumLength = 9)]
            [Display(Name = "Broj telefona")]
            public string BrojTelefona { get; set; }
          
            [Required]
            [EmailAddress(ErrorMessage = "Email adresa nije unešena u ispravnom formatu.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Mora biti najmanje 6 znakova, sadržavati broj i specijalni znak!", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lozinka")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potvrdi lozinku")]
            [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
            public string ConfirmPassword { get; set; }


            

            
        }

      
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            
                                

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            
           // returnUrl = returnUrl ?? Url.Content("~/Students/Create");
            returnUrl = returnUrl ?? Url.Content("~/Polaznik/Dodaj");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Korisnik { UserName = Input.Email, Email = Input.Email, Ime=Input.Ime,Prezime=Input.Prezime,
                    Adresa=Input.Adresa, BrojTelefona=Input.BrojTelefona,Grad=Input.Grad};
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _userManager.AddToRoleAsync(user, Enums.Roles.Polaznik.ToString()); //defaultna uloga je polaznik
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            if (ModelState.IsValid)
            {
                MailAddress address = new MailAddress(Input.Email);
                string userName = address.User;
                var user = new Korisnik
                {
                    UserName = userName,
                    Email = Input.Email,
                    Ime = Input.Ime,
                    Prezime = Input.Prezime,
                    Adresa = Input.Adresa,
                    BrojTelefona = Input.BrojTelefona,
                    Grad = Input.Grad
                };
            }
            
            return Page();
        }
    }
}
