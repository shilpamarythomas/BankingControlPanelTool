using Entities.Models;
using Entities.Models.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<BankUsers> BankUsers { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Countries Table
            modelBuilder.Entity<Countries>().HasData(
                new Countries {  CountryName = "UAE", CountryCode = "UAE",Id=1 });
            modelBuilder.Entity<Countries>().HasData(
                new Countries { CountryName = "United Kingdom", CountryCode = "UK",Id=2 });
            modelBuilder.Entity<Countries>().HasData(
                new Countries { CountryName = "United States", CountryCode = "US",Id=3 });

            //Seed Cities Table
            modelBuilder.Entity<Cities>().HasData(
                new Cities { CityName = "Dubai",CountryId=1,Id=1 });
            modelBuilder.Entity<Cities>().HasData(
                new Cities { CityName = "London", CountryId = 2 ,Id=2});
            modelBuilder.Entity<Cities>().HasData(
                new Cities { CityName = "New York", CountryId = 3,Id=3 });

            //Seed UserRoles Table
            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { RoleName = "Admin",Id=1 });
            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { RoleName = "User",Id=2});
        }
    }
}
