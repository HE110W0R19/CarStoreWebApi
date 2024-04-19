using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CarStoreDataAccess.JsonUtilities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CarStoreWEB.FirstTestDbContext;

public partial class FirstTestDbContext : DbContext
{
    //Connection String getter
    private readonly JsonUtilities JsonParser = new JsonUtilities();

    public FirstTestDbContext()
    {
    }

    public FirstTestDbContext(DbContextOptions<FirstTestDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(JsonParser.GetConnectionStr(@"..\ConnectionString.json"),
            ServerVersion.Parse("8.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
