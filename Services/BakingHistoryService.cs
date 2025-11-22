using BakingHistory.Models;

namespace BakingHistory.Services;

public class BakingHistoryService
{
    private readonly List<BakingEntry> _entries = new();
    private int _nextId = 1;

    public List<BakingEntry> GetAllEntries()
    {
        return _entries.OrderByDescending(e => e.TimeOfBaking).ToList();
    }

    public BakingEntry? GetEntry(int id)
    {
        return _entries.FirstOrDefault(e => e.Id == id);
    }

    public void AddEntry(BakingEntry entry)
    {
        entry.Id = _nextId++;
        _entries.Add(entry);
    }

    public void UpdateEntry(BakingEntry entry)
    {
        var existingEntry = _entries.FirstOrDefault(e => e.Id == entry.Id);
        if (existingEntry != null)
        {
            _entries.Remove(existingEntry);
            _entries.Add(entry);
        }
    }

    public void DeleteEntry(int id)
    {
        var entry = _entries.FirstOrDefault(e => e.Id == id);
        if (entry != null)
        {
            _entries.Remove(entry);
        }
    }
}
