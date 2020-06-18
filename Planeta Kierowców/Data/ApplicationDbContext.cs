using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planeta_Kierowców.Model;


namespace Planeta_Kierowców.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zlecenia> Zlecenia { get; set; }

        public DbSet<Przedzial> Przedzials { get; set; }

        public DbSet<Protokoly> Protokoly { get; set; }


    }
}
