using System.Collections.Generic;
using System.Linq;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.Interfaces;

using LiteDB;

namespace Bro2Bro.lib.Implementations
{
    public class LiteDbDatabase : IDatabase
    {
        private readonly string _connectionString = "main.db";
        
        public List<Bros> GetBros(string searchQuery)
        {
            using (var liteDb = new LiteDatabase(_connectionString))
            {
                return liteDb.GetCollection<Bros>().Find(a => a.DisplayName.Contains(searchQuery)).ToList();
            }
        }
    }
}