namespace ClientLourdWpf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<appointments> appointments { get; set; }
        public virtual DbSet<brokers> brokers { get; set; }
        public virtual DbSet<customers> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<brokers>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<brokers>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.brokers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.subject)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .HasMany(e => e.appointments)
                .WithRequired(e => e.customers)
                .WillCascadeOnDelete(false);
        }
    }
}
