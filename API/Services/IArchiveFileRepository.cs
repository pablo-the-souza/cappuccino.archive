using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Archive.API.Entities;
using Archive.API.ResourceParameters;

namespace Archive.API.Services
{
    public interface IArchiveFileRepository
    {    
        Task<IEnumerable<ArchiveFile>> GetFilesAsync();
        // IEnumerable<ArchiveFile> GetFiles(FilesResourceParameters boxesResourceParameters); 
        Task<ArchiveFile> GetFileAsync(Guid id);
        void AddFile(ArchiveFile archiveFile);
        void UpdateFile(ArchiveFile archiveFile);
        void DeleteFile(ArchiveFile archiveFile);
        bool FileExists(Guid fileId);
        Task<bool> SaveChangesAsync();
    }
}
