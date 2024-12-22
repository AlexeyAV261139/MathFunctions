using Microsoft.EntityFrameworkCore;

namespace ISOCI.DAL;

public class UserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User GetByEmail(string email)
    {
        var user = _context.Users
            .AsNoTracking()
            .FirstOrDefault(u => u.Email == email) ?? throw new Exception();

        return user;
    }
}