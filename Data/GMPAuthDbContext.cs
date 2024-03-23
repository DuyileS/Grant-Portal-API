using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GMP.API.Data
{
    public class GMPAuthDbContext : IdentityDbContext
    {
        public GMPAuthDbContext(DbContextOptions<GMPAuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userId = "c2d9da98-13b0-4bb9-b401-96d7ef1bc52d";
            var adminId = "582029be-d3bf-4ea1-a151-83e23abdeb12";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userId,
                    ConcurrencyStamp = userId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                 new IdentityRole
                {
                    Id = adminId,
                    ConcurrencyStamp = adminId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }

}
