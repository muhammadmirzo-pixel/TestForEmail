using Microsoft.EntityFrameworkCore;
using TestForEmail.AppsDbContext;
using TestForEmail.Models;

namespace TestForEmail.Services;

public class UserService
{
    private readonly AppDbContext appDbContext;
    public UserService(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    private static List<User> _users = new();

    public void Register(User user)
    {
        _users.Add(user);
        appDbContext.SaveChanges();
    }

    public User GetByEmail(string email) =>
        appDbContext.Users.FirstOrDefault(u => u.Email == email);

    public async Task<User> CreateUserAsync(User user)
    {
        var result = await this.appDbContext.Users.AddAsync(user);
        appDbContext.SaveChanges();
        return result.Entity;
    }
}
