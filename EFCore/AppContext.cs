// using Microsoft.EntityFrameworkCore''

using Kutubxona.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kutubxona.EdataBase;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<LibraryBooks> LibraryBooks { get; set; } = null!;
    public AppContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Settings.sql);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasKey(a => a.Id);
        // Настройка связи "один ко многим" с помощью Fluent API
        modelBuilder.Entity<User>()
            .HasMany(a => a.Books)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId);
        
        modelBuilder.Entity<Book>()
            .HasKey(b => b.BookId); 
    }
}