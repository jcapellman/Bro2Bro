using Bro2Bro.WebAPI.DataLayer.EFModel.EFObjects;

namespace Bro2Bro.WebAPI.DataLayer.EFModel {
    using System.Data.Entity;

    public class EFModel : DbContext {
        public EFModel() : base("name=EFModel") { }
        
        public DbSet<Users> Users { get; set; }    
    }
}