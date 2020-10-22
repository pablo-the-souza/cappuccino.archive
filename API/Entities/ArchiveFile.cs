using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Archive.API.Entities
{
    public class ArchiveFile
    {
        [Key]       
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("ArchiveBoxId")]
        public ArchiveBox ArchiveBox { get; set; }

        public Guid ArchiveBoxId { get; set; }
    }
}
