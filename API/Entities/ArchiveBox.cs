using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Archive.API.Entities
{
    public class ArchiveBox
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        public ICollection<ArchiveFile> ArchiveFiles { get; set; }
            = new List<ArchiveFile>();
    }
}
