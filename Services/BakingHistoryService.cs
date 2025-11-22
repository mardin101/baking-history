using BakingHistory.Models;

namespace BakingHistory.Services;

public class BakingHistoryService
{
    private readonly LocalStorageService _localStorage;
    private List<BakingEntry> _entries = new();
    private int _nextId = 1;
    private const string StorageKey = "bakingEntries";
    private bool _isInitialized = false;

    public BakingHistoryService(LocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    private async Task EnsureInitializedAsync()
    {
        if (!_isInitialized)
        {
            await LoadEntriesAsync();
            _isInitialized = true;
        }
    }

    private async Task LoadEntriesAsync()
    {
        var entries = await _localStorage.GetItemAsync<List<BakingEntry>>(StorageKey);
        if (entries != null && entries.Count > 0)
        {
            _entries = entries;
            _nextId = (_entries.Any() ? _entries.Max(e => e.Id) : 0) + 1;
        }
    }

    private async Task SaveEntriesAsync()
    {
        await _localStorage.SetItemAsync(StorageKey, _entries);
    }

    public async Task<List<BakingEntry>> GetAllEntriesAsync()
    {
        await EnsureInitializedAsync();
        return _entries.OrderByDescending(e => e.TimeOfBaking).ToList();
    }

    public async Task<BakingEntry?> GetEntryAsync(int id)
    {
        await EnsureInitializedAsync();
        return _entries.FirstOrDefault(e => e.Id == id);
    }

    public async Task AddEntryAsync(BakingEntry entry)
    {
        await EnsureInitializedAsync();
        entry.Id = _nextId++;
        _entries.Add(entry);
        await SaveEntriesAsync();
    }

    public async Task UpdateEntryAsync(BakingEntry entry)
    {
        await EnsureInitializedAsync();
        var existingEntry = _entries.FirstOrDefault(e => e.Id == entry.Id);
        if (existingEntry != null)
        {
            _entries.Remove(existingEntry);
            _entries.Add(entry);
            await SaveEntriesAsync();
        }
    }

    public async Task DeleteEntryAsync(int id)
    {
        await EnsureInitializedAsync();
        var entry = _entries.FirstOrDefault(e => e.Id == id);
        if (entry != null)
        {
            _entries.Remove(entry);
            await SaveEntriesAsync();
        }
    }
}
