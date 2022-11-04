using System.Collections.Generic;
using System.Reflection.Emit;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Db;

public class AppDbContext : DbContext
{
    public DbSet<TicTacToeGame> TicTacToeGames { get; set; } = default!;
    public DbSet<TicTacToeOption> TicTacToeOptions { get; set; } = default!;
    public DbSet<TicTacToeGameState> TicTacToeGameStates { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}