﻿using BlazorTodoApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodoApp.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    }
}
