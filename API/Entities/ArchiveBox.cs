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

        public ICollection<ArchivePolicy> ArchivePolicies { get; set; }
            = new List<ArchivePolicy>();
    }
}
