using DAL.Repositories;

namespace Core.Services;

public class HystoryService
{
    private readonly HistoryRepository _historyRepository;

    public HystoryService(HistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public void AddToHistory()
    {

    }
}
