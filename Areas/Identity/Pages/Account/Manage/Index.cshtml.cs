using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RS1SeminarskiRad2020.Models;

namespace RS1SeminarskiRad2020.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly SignInManager<Korisnik> _signInManager;

        public IndexModel(
            UserManager<Korisnik> userManager,
            SignInManager<Korisnik> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Ime")]
            public string Ime { get; set; }
            
            [Display(Name = "Prezime")]
            public string Prezime { get; set; }

            [Display(Name = "Grad")]
            public string Grad { get; set; }
            
            [Display(Name = "Adresa")]
            public string Adresa { get; set; }
            [Phone]
            [Display(Name = "Broj telefona")]
            public string BrojTelefona { get; set; }
            [Display(Name = "Profilna slika ")]
            public byte[] Slika { get; set; }
        }

        private async Task LoadAsync(Korisnik user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.Ime;
            var lastName = user.Prezime;
            var profilePicture = user.Slika;
            var adress = user.Adresa;
            var email = user.Email;
            var grad = user.Grad;
            Username = userName;
            Input = new InputModel
            {
                BrojTelefona = phoneNumber,
                Username = userName,
                Ime = firstName,
                Prezime = lastName,
                Slika = profilePicture,
                Grad = grad,
                Adresa = adress,
                Email = email,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }



            //ostali podaci
            var firstName = user.Ime;
            var lastName = user.Prezime;
            var adress = user.Adresa;
            var username = user.UserName;
            var email = user.Email;
            var grad = user.Grad;
            
            
            
            
            if (Input.Ime != firstName)
            {
                user.Ime = Input.Ime;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Prezime != lastName)
            {
                user.Prezime = Input.Prezime;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Grad != grad)
            {
                user.Grad = Input.Grad;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Adresa != adress)
            {
                user.Adresa = Input.Adresa;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Username != username)
            {
                user.UserName = Input.Username;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Email != email)
            {
                user.Email = Input.Email;
                await _userManager.UpdateAsync(user);
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.BrojTelefona != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.BrojTelefona);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //slika 
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.Slika = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Uspješno ste izmijenili podatke!";
            return RedirectToPage();
        }
    }
}
