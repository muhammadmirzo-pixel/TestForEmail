using Microsoft.EntityFrameworkCore;
using TestForEmail.AppsDbContext;
using TestForEmail.Models;

namespace TestForEmail.Services;

public class UserService
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<User> dbSet;
    public UserService(AppDbContext appDbContext, DbSet<User> dbSet)
    {
        this.appDbContext = appDbContext;
        this.dbSet = dbSet;
    }
    private static List<User> _users = new();

    public void Register(User user)
    {
        _users.Add(user);
        appDbContext.SaveChanges();
    }

    public User GetByEmail(string email) =>
        _users.FirstOrDefault(u => u.Email == email);

    public async Task<User> CreateUserAsync(User user)
    {
        var result = await this.dbSet.AddAsync(user);
        appDbContext.SaveChanges();
        return result.Entity;
    }
}
