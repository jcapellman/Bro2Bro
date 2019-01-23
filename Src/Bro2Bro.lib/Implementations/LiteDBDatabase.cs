using System;
using System.Collections.Generic;
using System.Linq;

using Bro2Bro.lib.DAL;
using Bro2Bro.lib.Interfaces;
using Bro2Bro.lib.Transports;
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

        public List<Messages> GetMessages(string senderBroId, string receiverBroId)
        {
            using (var liteDb = new LiteDatabase(_connectionString))
            {
                var db = liteDb.GetCollection<Messages>();

                return db.Find(a => a.SenderBroId == senderBroId && a.ReceiverBroId == receiverBroId && a.Active).ToList();
            }
        }

        public bool SendMessage(string senderBroId, string receiverBroId, string content)
        {
            using (var liteDb = new LiteDatabase(_connectionString))
            {
                var db = liteDb.GetCollection<Messages>();

                var message = new Messages
                {
                    Active = true,
                    Content = content,
                    ReceiverBroId = receiverBroId,
                    Timestamp = DateTime.Now,
                    SenderBroId = senderBroId
                };

                db.Insert(message);

                return true;
            }
        }

        public List<MessageThreadListingResponseItem> GetMessageThreads(string receiverBroId)
        {
            using (var liteDb = new LiteDatabase(_connectionString))
            {
                var db = liteDb.GetCollection<Messages>();

                var threads = new List<MessageThreadListingResponseItem>();

                var results = db.Find(a => a.ReceiverBroId == receiverBroId && a.Active).ToList();

                foreach (var senderBroId in results.GroupBy(p => p.SenderBroId).Select(g => g.Key).ToList())
                {
                    threads.Add(new MessageThreadListingResponseItem
                    {
                        BroId = senderBroId,
                        LastMessage = results.Where(a => a.SenderBroId == senderBroId).Max(a => a.Timestamp),
                        MessageCount = results.Count(a => a.SenderBroId == senderBroId)
                    });
                }

                return threads;
            }
        }
    }
}