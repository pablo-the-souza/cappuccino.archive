using System;
using System.Collections.Generic;
using Archive.API.Entities;

namespace Archive.API.Services
{
    public interface IArchiveFileRepository
    {    
        IEnumerable<ArchiveFile> GetFiles();
        // ArchiveFile GetFile(Guid archiveFileId);
        // void AddFile(ArchiveFile archiveFile);
        // void UpdateFile(ArchiveFile archiveFile);
        // void DeleteFile(ArchiveFile archiveFile);
        bool Save();
    }
}
