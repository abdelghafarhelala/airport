namespace project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model110")
        {
        }

        public virtual DbSet<catloge> catloges { get; set; }
        public virtual DbSet<flight> flights { get; set; }
        public virtual DbSet<from> froms { get; set; }
        public virtual DbSet<passenger> passengers { get; set; }
        public virtual DbSet<select_dir> select_dir { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<catloge>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<catloge>()
                .HasMany(e => e.flights)
                .WithOptional(e => e.catloge)
                .HasForeignKey(e => e.cat_id);

            modelBuilder.Entity<from>()
                .Property(e => e.from1)
                .IsUnicode(false);

            modelBuilder.Entity<from>()
                .HasMany(e => e.flights)
                .WithOptional(e => e.from)
                .HasForeignKey(e => e.fr_id);

            modelBuilder.Entity<passenger>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .HasMany(e => e.flights)
                .WithOptional(e => e.passenger)
                .HasForeignKey(e => e.p_id);

            modelBuilder.Entity<select_dir>()
                .Property(e => e.dir)
                .IsUnicode(false);

            modelBuilder.Entity<select_dir>()
                .HasMany(e => e.flights)
                .WithOptional(e => e.select_dir)
                .HasForeignKey(e => e.s_id);
        }
    }
}
