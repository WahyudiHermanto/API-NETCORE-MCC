using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext //Entity Framework
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<Profilling> Profilling { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(ac => ac.Account)
                .WithOne(em => em.Employee)
                .HasForeignKey<Account>(em => em.NIK);

            modelBuilder.Entity<University>()
                .HasMany(edu => edu.Education)
                .WithOne(uni => uni.University);

            modelBuilder.Entity<Profilling>()
                .HasOne(ac => ac.Account)
                .WithOne(pro => pro.Profilling)
                .HasForeignKey<Account>(em => em.NIK);

            modelBuilder.Entity<Education>()
                .HasMany(pro => pro.Profilling)
                .WithOne(edu => edu.Education);

            modelBuilder.Entity<Account>()
               .HasOne(profilling => profilling.Profilling)
               .WithOne(account => account.Account)
               .HasForeignKey<Profilling>(nik => nik.NIK);

            modelBuilder.Entity<AccountRole>()
                .HasOne(acc => acc.Account)
                .WithMany(acr => acr.AccountRole);

            modelBuilder.Entity<AccountRole>()
                .HasOne(ro => ro.Role)
                .WithMany(acr => acr.AccountRole);

        }


    }
  
}

