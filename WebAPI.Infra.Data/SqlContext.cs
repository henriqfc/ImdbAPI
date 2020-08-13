using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WepAPI.Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public override int SaveChanges()
        {


            return base.SaveChanges();
        }

        private void ConfigUser(ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(c => c.Id).HasName("id");
                e.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(c => c.Active).HasColumnName("active");
                e.Property(c => c.DateInsert).HasColumnName("dateInsert");
                e.Property(c => c.DateUpdate).HasColumnName("dateUpdate");
                e.Property(c => c.Email).HasColumnName("email").HasMaxLength(30);
                e.Property(c => c.isAdmin).HasColumnName("isAdmin");
                e.Property(c => c.Login).HasColumnName("login").HasMaxLength(30);
                e.Property(c => c.Name).HasColumnName("name").HasMaxLength(50);
                e.Property(c => c.Password).HasColumnName("password").HasMaxLength(250);
            });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseIdentityColumns();
            builder.HasDefaultSchema("DadosIMDB");
            ConfigUser(builder);
            builder.Entity<Movie>().ToTable("Movie");
            builder.Entity<Vote>().ToTable("Vote");
        }
    }
}
