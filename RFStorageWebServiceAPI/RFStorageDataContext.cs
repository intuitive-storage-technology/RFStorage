namespace RFStorageWebServiceAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RFStorageDataContext : DbContext
    {
        public RFStorageDataContext()
            : base("name=RFStorageDataContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bruger> Bruger { get; set; }
        public virtual DbSet<Ordre> Ordre { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Vare> Vare { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bruger>()
                .Property(e => e.BrugerID)
                .IsFixedLength();

            modelBuilder.Entity<Bruger>()
                .HasMany(e => e.Ordre)
                .WithRequired(e => e.Bruger)
                .HasForeignKey(e => e.Udleverer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordre>()
                .Property(e => e.Udleverer)
                .IsFixedLength();
        }
    }
}
