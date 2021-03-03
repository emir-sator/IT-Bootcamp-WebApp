using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RS1SeminarskiRad2020.Models;

namespace RS1SeminarskiRad2020.Data
{


   public class ApplicationDbContext: IdentityDbContext
   {


      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) {
      }

    
      public DbSet<Kurs> Kursevi { get; set; }
      public DbSet<KorisnikKurs> KorisnikKurs { get; set; }
      public DbSet<Polaznik> Studenti { get; set; }
      public DbSet<Predavac> Predavac { get; set; }
      public DbSet<Ciklus> Ciklus { get; set; }
      public DbSet<Grupa> Grupa { get; set; }
      public DbSet<PolaznikGrupa> PolaznikGrupa { get; set; }
      public DbSet<Korisnik> Korisnici { get; set; }
      public DbSet<Dokument> Dokument { get; set; }
      public DbSet<Predavanje> Predavanje { get; set; }
      public DbSet<TipDokumenta> TipDokumenta { get; set; }
      public DbSet<Projekat> Projekat { get; set; }
      public DbSet<ProjekatBaza> ProjekatBaza { get; set; }
      public DbSet<Kabinet> Kabineti { get; set; }

      public DbSet<Subscription> Subscriptions { get; set; }





      protected override void OnModelCreating(ModelBuilder builder) {
         base.OnModelCreating(builder);
         builder.HasDefaultSchema("Identity");
         builder.Entity<IdentityUser>(entity => {
            entity.ToTable(name: "User");
         });
         builder.Entity<IdentityRole>(entity => {
            entity.ToTable(name: "Role");
         });
         builder.Entity<IdentityUserRole<string>>(entity => {
            entity.ToTable("UserRoles");
         });
         builder.Entity<IdentityUserClaim<string>>(entity => {
            entity.ToTable("UserClaims");
         });
         builder.Entity<IdentityUserLogin<string>>(entity => {
            entity.ToTable("UserLogins");
         });
         builder.Entity<IdentityRoleClaim<string>>(entity => {
            entity.ToTable("RoleClaims");
         });
         builder.Entity<IdentityUserToken<string>>(entity => {
            entity.ToTable("UserTokens");
         });

          builder.Entity<PolaznikGrupa>().HasKey(pg=> new {pg.GrupaID,pg.KursID,pg.KorisnikId });
          builder.Entity<KorisnikKurs>().HasKey(kk => new {kk.PrijavaID});

        }





    }

}
