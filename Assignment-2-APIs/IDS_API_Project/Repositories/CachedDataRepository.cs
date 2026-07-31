/* This is an in-memory cached implementation of the IDataRepository interface */

using IDS_API_Project.Models;
using Microsoft.Extensions.Caching.Memory;

namespace IDS_API_Project.Repositories;

public class CachedDataRepository : IDataRepository
{
    private readonly DataRepository _inner;
    private readonly IMemoryCache _cache;

    public CachedDataRepository(DataRepository inner, IMemoryCache cache)
    {
        _inner = inner;
        _cache = cache;
    }

    public List<DataItem> GetAll()
    {
        // Used '?' to remove the warning that cachedData may be uninitialized
        List<DataItem>? cachedData; 

        // Check if the data exists in the cache
        bool exists = _cache.TryGetValue("all-data", out cachedData);
        if (exists)
        {
            return cachedData!;
        }

        // If data doesn't exist in cache, ask the real repository for the data.
        List<DataItem> data = _inner.GetAll();
        // Store it in cache
        _cache.Set(
            "all-data",
            data,
            TimeSpan.FromMinutes(10) // Set the cache expiration to 10 minutes
        );
        return data;
    }   
}
