namespace Safaryan_Alla.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Projects")]
    public partial class ProjectEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectEntity()
        {
            Notes = new HashSet<NoteEntity>();
        }

        [Key]
        public long ProjectId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Description { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string ProjectLeader { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string StartDate { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string PlanEndDate { get; set; }

        public long GroupId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoteEntity> Notes { get; set; }

        public virtual GroupEntity ResearchGroups { get; set; }
    }
}
