using DAL.Entities;
using ISOCI.DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class HistoryRepository
{
    private readonly ApplicationContext _context;

    public HistoryRepository(ApplicationContext context)
    {
        _context = context;
    }    

    public void AddToHistory(History history)
    {
        _context.History.Add(history);
        _context.SaveChanges();
    }

    public List<History> GetAllHystoryByUserId(long userId)
    {
        var allHystory = _context.History
            .Include(x => x.User)
            .Where(h => h.User.Id == userId)
            .ToList();

        return allHystory;
    }
}
