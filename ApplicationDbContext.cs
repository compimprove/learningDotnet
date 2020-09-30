using System;
using System.Diagnostics.CodeAnalysis;
using First.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace First
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
    }

}
