using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiProjects.Domain
{
    public partial class WebApiContext : DbContext
    {
        public WebApiContext()
        {
        }

        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
