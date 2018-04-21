using System;
using System.IO;
using System.Threading.Tasks;
using Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private const string DbCacheKey = "database";

        private readonly IMemoryCache _memoryCache;

        public DatabaseProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<Database> GetDatabase()
        {
            if (_memoryCache.TryGetValue(DbCacheKey, out Database database))
            {
                return database;
            }

            string databaseStr = await File.ReadAllTextAsync("database.json");
            database = JsonConvert.DeserializeObject<Database>(databaseStr);

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1));
            _memoryCache.Set(DbCacheKey, database, cacheEntryOptions);

            return database;
        }
    }
}
