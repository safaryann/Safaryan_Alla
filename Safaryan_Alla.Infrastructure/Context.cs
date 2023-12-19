using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Safaryan_Alla.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<NoteEntity> Notes { get; set; }
        public virtual DbSet<ProjectEntity> Projects { get; set; }
        public virtual DbSet<GroupEntity> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.Projects)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupEntity>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.ResearchGroups)
                .WillCascadeOnDelete(false);
        }
    }
}
