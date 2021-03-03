using EnumsNET;
using Microsoft.AspNetCore.Identity;
using RS1SeminarskiRad2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RS1SeminarskiRad2020.Data
{
    public static class ContextSeed
    {
        
        public static async Task SeedRolesAsync(UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Automatsko punjenje tabele uloga
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Polaznik.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Predavač.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Osoblje.ToString()));
        }
        public static async Task Administratori(UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            //automatsko dodavanje admina 
            var admin1 = new Korisnik
            {
                UserName = "Administrator1",
                Email = "admin1@edu.fit.ba",
                Ime = "Emir",
                Prezime = "Šator",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != admin1.Id))
            {
                var user = await userManager.FindByEmailAsync(admin1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin1, "Admin5.");
                    await userManager.AddToRoleAsync(admin1, Enums.Roles.Administrator.ToString());

                }

            }
            var admin2 = new Korisnik
            {
                UserName = "Administrator2",
                Email = "admin2@edu.fit.ba",
                Ime = "Adnan",
                Prezime = "Mujkić",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != admin2.Id))
            {
                var user = await userManager.FindByEmailAsync(admin2.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin2, "Admin5.");
                    await userManager.AddToRoleAsync(admin2, Enums.Roles.Administrator.ToString());

                }

            }
            var admin3 = new Korisnik
            {
                UserName = "Administrator3",
                Email = "admin3@edu.fit.ba",
                Ime = "Amer",
                Prezime = "Alihodžić",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != admin3.Id))
            {
                var user = await userManager.FindByEmailAsync(admin3.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(admin3, "Admin5.");
                    await userManager.AddToRoleAsync(admin3, Enums.Roles.Administrator.ToString());

                }

            }
        }

        public static async Task Predavaci(UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        {
            //automatsko dodavanje predavaca
            var predavac1 = new Korisnik
            {
                UserName = "Predavac1",
                Email = "predavac1@edu.fit.ba",
                Ime = "test1",
                Prezime = "test1",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != predavac1.Id))
            {
                var user = await userManager.FindByEmailAsync(predavac1.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(predavac1, "Predavac1.");
                    await userManager.AddToRoleAsync(predavac1, Enums.Roles.Predavač.ToString());

                }

            }
            var predavac2 = new Korisnik
            {
                UserName = "Predavac2",
                Email = "predavac2@edu.fit.ba",
                Ime = "test2",
                Prezime = "test2",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != predavac2.Id))
            {
                var user = await userManager.FindByEmailAsync(predavac2.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(predavac2, "Predavac1.");
                    await userManager.AddToRoleAsync(predavac2, Enums.Roles.Predavač.ToString());

                }

            }
            var predavac3 = new Korisnik
            {
                UserName = "Predavac3",
                Email = "predavac3@edu.fit.ba",
                Ime = "test3",
                Prezime = "test3",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != predavac3.Id))
            {
                var user = await userManager.FindByEmailAsync(predavac3.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(predavac3, "Predavac1.");
                    await userManager.AddToRoleAsync(predavac3, Enums.Roles.Predavač.ToString());

                }

            }
        }

        //public static async Task Polaznik(UserManager<Korisnik> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    //automatsko dodavanje polaznika
        //    var student1 = new Korisnik
        //    {
        //        UserName = "Polaznik1",
        //        Email = "polaznik1@edu.fit.ba",
        //        Ime = "test1",
        //        Prezime = "test1",
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true
        //    };
            
        //    if (userManager.Users.All(u => u.Id != student1.Id))
        //    {
        //        var user = await userManager.FindByEmailAsync(student1.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(student1, "Polaznik1.");
        //            await userManager.AddToRoleAsync(student1, Enums.Roles.Polaznik.ToString());

        //        }

        //    }

        //    var student2 = new Korisnik
        //    {
        //        UserName = "Polaznik2",
        //        Email = "polaznik2@edu.fit.ba",
        //        Ime = "test2",
        //        Prezime = "test2",
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true
        //    };

        //    if (userManager.Users.All(u => u.Id != student2.Id))
        //    {
        //        var user = await userManager.FindByEmailAsync(student2.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(student2, "Polaznik1.");
        //            await userManager.AddToRoleAsync(student2, Enums.Roles.Polaznik.ToString());

        //        }

        //    }
        //    var student3 = new Korisnik
        //    {
        //        UserName = "Polaznik3",
        //        Email = "polaznik3@edu.fit.ba",
        //        Ime = "test2",
        //        Prezime = "test2",
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true
        //    };

        //    if (userManager.Users.All(u => u.Id != student3.Id))
        //    {
        //        var user = await userManager.FindByEmailAsync(student3.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(student3, "Polaznik1.");
        //            await userManager.AddToRoleAsync(student3, Enums.Roles.Polaznik.ToString());

        //        }

        //    }



        //}
    }
}
