using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users {get;set;}
        public DbSet<Employee> Employees{get;set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
                      {
                          entity.HasNoKey(); // Define the primary key
                          entity.ToView(null);
                      });

            modelBuilder.Entity<Employee>(entity =>
                      {
                          entity.HasKey(a => a.NID); // Define the primary key
                          entity.ToView("v_MT_Employee");
                      });
        }
    }
}