using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Data
{
    public class AutoHubDbContext : IdentityDbContext<IdentityUser>
    {
        public AutoHubDbContext()
        {
            
        }


        public AutoHubDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Engine> Engines { get; set; } = null!;
        public virtual DbSet<Gearbox> Gearboxes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ProductClient> ProductClients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
