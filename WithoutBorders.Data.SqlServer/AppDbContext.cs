using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WithoutBorders.Data.Entities;

namespace WithoutBorders.Data.SqlServer
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) { }
        
        public DbSet<Kid> Kids { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Camp> Camps { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MainEntity> MainEntities { get; set; }
        public DbSet<SelectedMain> SelectedMains { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "1",
                UserName = "tweeker",
                NormalizedUserName = "TWEEKER",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser("tweeker"), "tweekeradmin"),
                SecurityStamp = string.Empty
            });
            
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "2",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser("tweeker"), "locachicampadmin"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "1",
                RoleId = "1"
            });
            
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "2",
                RoleId = "1"
            });
        }
        
    }
}