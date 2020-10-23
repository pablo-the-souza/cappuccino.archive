using System;
using System.Collections.Generic;
using Archive.API.Entities;
using Archive.API.ResourceParameters;

namespace Archive.API.Services
{
    public interface IArchiveFileRepository
    {    
        IEnumerable<ArchiveFile> GetFiles();
        IEnumerable<ArchiveFile> GetFiles(FilesResourceParameters boxesResourceParameters); 
        ArchiveFile GetFile(Guid fileId);
        // void AddFile(ArchiveFile archiveFile);
        // void UpdateFile(ArchiveFile archiveFile);
        // void DeleteFile(ArchiveFile archiveFile);
        bool FileExists(Guid fileId);
        bool Save();
    }
}
