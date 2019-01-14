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
            if (string.IsNullOrEmpty(searchQuery))
            {
                return new List<Bros>();
            }

            using (var liteDb = new LiteDatabase(_connectionString))
            {
                return liteDb.GetCollection<Bros>().Find(a => a.DisplayName.Contains(searchQuery)).ToList();
            }
        }

        public bool RegisterBro(string broId, string displayName)
        {
            if (string.IsNullOrEmpty(broId) || string.IsNullOrEmpty(displayName))
            {
                return false;
            }

            using (var liteDb = new LiteDatabase(_connectionString))
            {
                var db = liteDb.GetCollection<Bros>();

                db.Insert(new Bros
                {
                    DisplayName = displayName,
                    BroID = broId
                });
                
                return true;
            }
        }

        public bool ClearBros()
        {
            using (var liteDb = new LiteDatabase(_connectionString))
            {
                var db = liteDb.GetCollection<Bros>();

                db.Delete(a => a.Active);
                    
                return true;
            }
        }
    }
}