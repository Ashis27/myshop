using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Identity.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure
{
    public class ApplicationUserDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDBContext(DbContextOptions<ApplicationUserDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
