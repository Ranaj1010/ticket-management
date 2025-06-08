using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ticket_management_api.Data.Entities;

namespace ticket_management_api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(builder =>
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Id).HasConversion(
                    id => id.Value,
                    value => new AccountId(value));
                builder.Property(c => c.CoordinatorId).HasConversion(
                    id => id.Value,
                    value => new AccountId(value));
                builder.OwnsOne(c => c.Address, builder =>
                    {
                        builder.Property(c => c.Street1).HasMaxLength(100);
                        builder.Property(c => c.Village).HasMaxLength(100);
                        builder.Property(c => c.City).HasMaxLength(100);
                        builder.Property(c => c.Province).HasMaxLength(100);
                        builder.Property(c => c.Country).HasMaxLength(100);
                        builder.Property(c => c.PostalCode).HasMaxLength(100);
                    }
                );
            });
        }
    }
}