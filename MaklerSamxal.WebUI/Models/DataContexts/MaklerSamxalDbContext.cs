using MaklerSamxal.WebUI.Models.Entity;
using MaklerSamxal.WebUI.Models.Entity.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaklerSamxal.WebUI.Models.DataContexts
{
    public class MaklerSamxalDbContext : IdentityDbContext<MaklerUser, MaklerRole, int, MaklerUserClaim, MaklerUserRole, MaklerUserLogin, MaklerRoleClaim, MaklerUserToken>
    {
        public MaklerSamxalDbContext(DbContextOptions options)
             : base(options)
        {

        }



        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Testimionals> Testimionalss { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscrice> Subscrices { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MaklerUser>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("Users", "Membership");

            });

            builder.Entity<MaklerRole>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("Roles", "Membership");

            });

            builder.Entity<MaklerUserRole>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserRoles", "Membership");

            });

            builder.Entity<MaklerUserClaim>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserClaims", "Membership");

            });

            builder.Entity<MaklerRoleClaim>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("RoleClaims", "Membership");

            });
            builder.Entity<MaklerUserToken>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserTokens", "Membership");

            });
            builder.Entity<MaklerUserLogin>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserLogins", "Membership");

            });
        }
    }
}



