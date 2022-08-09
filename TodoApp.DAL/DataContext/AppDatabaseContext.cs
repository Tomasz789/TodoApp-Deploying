using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
#pragma warning disable S927 // Parameter names should match base declaration and other partial definitions

namespace TodoApp.DAL.DataContext
{
    public class AppDatabaseContext : IdentityDbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> contextOptions) : base(contextOptions)
        {

        }

       // public DbSet<User> Users { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        public DbSet<TodoTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoList>().HasMany(t => t.Tasks).WithOne(t => t.TodoList).HasForeignKey(t => t.TaskListId);
            modelBuilder.Entity<IdentityUser>().HasMany(t => t.TodoLists).WithOne(t => t.User);
            //modelBuilder.Seed();
        }
    }
}
