using Bro2Bro.WebAPI.DataLayer.EFModel.EFObjects;

namespace Bro2Bro.WebAPI.DataLayer.EFModel {
    using System.Data.Entity;

    public class EntityFactory : DbContext {
        public EntityFactory() : base("name=EFModel") { }
        
        public DbSet<Users> Users { get; set; }

        public DbSet<Messages> Messages { get; set; }
    }
}