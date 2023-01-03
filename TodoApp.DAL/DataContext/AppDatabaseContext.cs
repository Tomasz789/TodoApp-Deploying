using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Entities.Budgets;
#pragma warning disable S927 // Parameter names should match base declaration and other partial definitions

namespace TodoApp.DAL.DataContext
{
    public class AppDatabaseContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<TodoList> TodoLists { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<TodoTask> Tasks { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Notify> Notifies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoList>().HasMany(t => t.Tasks).WithOne(t => t.TodoList).HasForeignKey(t => t.TaskListId);
            modelBuilder.Entity<AppUser>().HasMany(t => t.TodoLists).WithOne(t => t.User).HasForeignKey(t => t.UserId);
            modelBuilder.Entity<AppUser>().HasMany(n => n.Notes).WithOne(u => u.User).HasForeignKey(t => t.UserId);
            modelBuilder.Entity<AppUser>().HasMany(s => s.ShoppingLists).WithOne(u => u.User).HasForeignKey(t => t.UserId);
            modelBuilder.Entity<AppUser>().HasMany(i => i.Incomes).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<AppUser>().HasMany(e => e.Expenses).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<AppUser>().HasMany(n => n.Notifies).WithOne(u => u.User).HasForeignKey(u => u.UserId);
        }
    }
}
