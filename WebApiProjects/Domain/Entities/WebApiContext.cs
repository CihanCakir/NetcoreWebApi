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
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-390N7L8\\SQLEXPRESS;Initial Catalog=WebApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.Property(e => e.Category).HasMaxLength(50);

            //    entity.Property(e => e.Name).HasMaxLength(50);

            //    entity.Property(e => e.Price).HasColumnType("money");
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.Property(e => e.Email).HasMaxLength(100);

            //    entity.Property(e => e.Name).HasMaxLength(50);

            //    entity.Property(e => e.Password).HasMaxLength(8);

            //    entity.Property(e => e.RefreshToken).HasMaxLength(500);

            //    entity.Property(e => e.RefreshTokenEndDate).HasColumnType("datetime");

            //    entity.Property(e => e.SurName).HasMaxLength(50);
            //});

         //   OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
