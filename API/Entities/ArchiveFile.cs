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
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [ForeignKey("ArchiveBoxId")]
        public ArchiveBox ArchiveBox { get; set; }

        public Guid ArchiveBoxId { get; set; }

        [MaxLength(50)]
        public string PolicyType { get; set; }

        [MaxLength(50)]
        public string PolicyNumber { get; set; }

        public DateTimeOffset DateStart { get; set; }
        
        public DateTimeOffset DateEnd { get; set; }

        [MaxLength(1000)]
        public string Comments { get; set; }
    }
}
