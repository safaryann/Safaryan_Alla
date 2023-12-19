namespace Safaryan_Alla.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Groups")]
    public partial class GroupEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupEntity()
        {
            Projects = new HashSet<ProjectEntity>();
        }

        [Key]
        public long GroupId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string GroupName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string GroupLeader { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectEntity> Projects { get; set; }
    }
}
