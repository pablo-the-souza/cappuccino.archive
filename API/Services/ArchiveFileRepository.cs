

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Archive.API.Entities;
using Archive.API.ResourceParameters;
using Microsoft.EntityFrameworkCore;

namespace Archive.API.Services
{
    public class ArchiveFileRepository : IArchiveFileRepository, IDisposable
    {

        
        private readonly ArchiveContext _context;

        public ArchiveFileRepository(ArchiveContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<ArchiveFile>> GetFilesAsync()
        {

            return await _context.ArchiveFiles
                .Include(f => f.ArchiveBox)
                .OrderBy(f => f.Name).ToListAsync();
        }

        // public IEnumerable<ArchiveFile> GetFiles(FilesResourceParameters filesResourceParameters)
        // {
        //     if (filesResourceParameters == null) 
        //     {
        //         throw new ArgumentNullException(nameof(filesResourceParameters));
        //     }

        //     if(string.IsNullOrWhiteSpace(filesResourceParameters.searchByName) &&
        //        string.IsNullOrWhiteSpace(filesResourceParameters.searchByCode)) 
        //     {
        //         return GetFilesAsync();
        //     }

        //     //deferred execution
        //     var collection = _context.ArchiveFiles as IQueryable<ArchiveFile>;

        //     if(!string.IsNullOrWhiteSpace(filesResourceParameters.searchByName)) 
        //     {
        //         var searchByName = filesResourceParameters.searchByName.Trim();
        //         collection = collection.Where(b => b.Name.Contains(searchByName));
        //     }

        //     if(!string.IsNullOrWhiteSpace(filesResourceParameters.searchByCode)) 
        //     {
        //         var searchByCode = filesResourceParameters.searchByCode.Trim();
        //         collection = collection.Where(b => b.Code.Contains(searchByCode));
        //     }     

        //     return collection.ToList();
        // }
        public async Task <ArchiveFile> GetFileAsync(Guid fileId)
        {

            if (fileId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(fileId));
            }

            return await _context.ArchiveFiles
              .Where(c => c.Id == fileId).FirstOrDefaultAsync();
        }

        public void AddFile(ArchiveFile file)
        {

            if (file == null)
            {
                throw new ArgumentNullException(nameof(ArchiveFile));
            }
            // always set the AuthorId to the passed-in authorId
            
            _context.Add(file); 
        }         

        public void DeleteFile(ArchiveFile file)
        {
            _context.ArchiveFiles.Remove(file);
        }

        public void UpdateFile(ArchiveFile file)
        {
            // no code in this implementation
        }

        public bool FileExists(Guid fileId)
        {
            if (fileId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(fileId));
            }

            return _context.ArchiveFiles.Any(a => a.Id == fileId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
