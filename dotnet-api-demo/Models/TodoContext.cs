using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api_demo.Models;

public class TodoContext : DbContext
{
    private readonly Action<TodoContext, ModelBuilder> _modelCustomizer;


    public TodoContext()
    {

    }

    public TodoContext(DbContextOptions<TodoContext> options, Action<TodoContext, ModelBuilder> modelCustomizer = null)
    : base(options)
    {
        _modelCustomizer = modelCustomizer;
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True");
        }
    }

}