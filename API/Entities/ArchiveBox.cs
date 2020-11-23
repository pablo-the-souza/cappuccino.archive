using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Archive.API.Entities
{
    public class ArchiveBox
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string DestructionFlag { get; set; }
        
        [MaxLength(50)]
        public string Reference { get; set; }

        public DateTimeOffset DateLeftOffice { get; set; }

        [MaxLength(1000)]
        public string Comments { get; set; }

        public ICollection<ArchiveFile> ArchiveFiles { get; set; }
            = new List<ArchiveFile>();
    }
}
