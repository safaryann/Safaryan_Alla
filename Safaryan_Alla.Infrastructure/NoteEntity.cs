namespace Safaryan_Alla.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notes")]
    public partial class NoteEntity
    {
        [Key]
        public long NoteId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string NoteDate { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string CreatorName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string DetailedDescription { get; set; }

        public long ProjectId { get; set; }

        public virtual ProjectEntity Projects { get; set; }
    }
}
