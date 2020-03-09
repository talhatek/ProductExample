namespace Ornek.Dal.Concrete.EF.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Ornek.Entities.Models;

    public partial class OrnekContext : DbContext
    {
        public OrnekContext()
            : base("name=OrnekContext")
        {
        }

        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
