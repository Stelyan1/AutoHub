using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoHub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoHub.Data
{
    public class AutoHubDbContext : DbContext
    {
        public AutoHubDbContext()
        {
            
        }


        public AutoHubDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
