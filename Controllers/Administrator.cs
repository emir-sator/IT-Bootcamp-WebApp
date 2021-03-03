using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using RS1SeminarskiRad2020.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Controllers
{
    public class Administrator: Controller
    {
     
        private readonly UserManager<Korisnik> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly  ApplicationDbContext db;

        
        
        public Administrator(UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext _db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            db = _db;
        }
    

        public IActionResult Upravljanje()
        {
            return View();
        }

        public IActionResult Crud()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DodajUlogu()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }


        [HttpPost]
        [Authorize(Roles="Administrator")]
        
        public async Task<IActionResult> DodajUlogu(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("DodajUlogu");
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var UserRolesVM = new List<UserRolesVM>();
            foreach (Korisnik user in users)
            {
                var thisViewModel = new UserRolesVM();
                thisViewModel.UserId = user.Id;
                thisViewModel.UserName = user.Email;
                thisViewModel.Email = user.Email;
                thisViewModel.Ime = user.Ime;
                thisViewModel.Prezime = user.Prezime;
                thisViewModel.Roles = await GetUserRoles(user);
                UserRolesVM.Add(thisViewModel);
            }
            return View(UserRolesVM);
        }


        private async Task<List<string>> GetUserRoles(Korisnik user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Manage(string userId)
        {
            
            ViewBag.userId = userId;
           
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Korisnik sa ID-em =  {userId} ne može biti pronađen.";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {

                    userRolesViewModel.Selected = true;

                }
                
                else
                {
                    userRolesViewModel.Selected = false;
                }

                model.Add(userRolesViewModel);
              
            }
            return View(model);
        }
  

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> IzbrisiUlogu(string id)
        {
            var uloga = await _roleManager.FindByIdAsync(id);

            if (uloga == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID = {id} ne postoji";
                return View("NotFound");
            }
            else
            {
                var rezultat = await _roleManager.DeleteAsync(uloga);

                if (rezultat.Succeeded)
                {
                    return RedirectToAction("DodajUlogu");
                }

                foreach (var error in rezultat.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("DodajUlogu");
            }
        }


    }
}
