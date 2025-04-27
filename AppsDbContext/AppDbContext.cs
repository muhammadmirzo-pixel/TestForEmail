using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestForEmail.Models;

namespace TestForEmail.AppsDbContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
}

